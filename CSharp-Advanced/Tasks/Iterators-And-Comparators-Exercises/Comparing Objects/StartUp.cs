using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace IteratorsAndComparators
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            List<Person> listOfPersons = new List<Person>();            

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArg = input.Split(' ').ToArray();
                string name = inputArg[0];
                int age = int.Parse(inputArg[1]);
                string town = inputArg[2];

                Person person = new Person(name, age, town);

                listOfPersons.Add(person);
            }

            int n = int.Parse(Console.ReadLine());

            int matchesCount = 0;

            Person personToCompare = listOfPersons[n - 1];
           
            foreach (var person in listOfPersons)
            {
                if (personToCompare.CompareTo(person) == 0)
                {
                    matchesCount++;
                }
            }

            if (matchesCount <= 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                int notMatchesCount = listOfPersons.Count - matchesCount;
                Console.WriteLine($"{matchesCount} {notMatchesCount} {listOfPersons.Count}");
            }
        }
    }
}
