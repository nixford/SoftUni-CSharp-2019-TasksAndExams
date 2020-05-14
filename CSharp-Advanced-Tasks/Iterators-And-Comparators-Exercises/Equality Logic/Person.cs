﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;           
        }
        public string Name { get; set; }
        public int Age { get; set; }       

        public int CompareTo(Person person)
        {
            int result = 1;
            
            if (person != null)
            {
                result = this.Name.CompareTo(person.Name);
                if (result == 0)
                {
                    result = this.Age.CompareTo(person.Age);                    
                }                
            }
            return result;
        }
        public override bool Equals(object obj)
        {
            if (obj is Person person)
            {
                return this.Name == person.Name && this.Age == this.Age;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }
    }
}
