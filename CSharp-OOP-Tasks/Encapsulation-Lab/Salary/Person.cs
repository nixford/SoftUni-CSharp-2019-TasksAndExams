using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int Age { get; private set; }

        public decimal Salary { get; set; }

        public void IncreaseSalary(decimal percentage)
        {
            decimal delimeter = 0;
            if (this.Age > 30)
            {
                delimeter = 100;
            }
            else
            {
                delimeter = 200;
            }

            this.Salary += this.Salary * (percentage / delimeter);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.");

            return sb.ToString().TrimEnd();
        }
    }
}
