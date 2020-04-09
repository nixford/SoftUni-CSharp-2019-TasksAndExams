using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Order_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Person> persons = new List<Person>();


            while (input != "End")
            {
                var data = input.Split();

                var people = new Person();

                people.Name = data[0];
                people.ID = data[1];
                people.Age = int.Parse(data[2]);

                persons.Add(people);

                input = Console.ReadLine();
            }

            foreach (var person in persons.OrderBy(person => person.Age))
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");

            }
        }

    }

    class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
    }
}
