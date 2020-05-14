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
            SortedSet<Person> sortedSet = new SortedSet<Person>();
            HashSet<Person> hashSet = new HashSet<Person>();

            int n = int.Parse(Console.ReadLine());

            string input = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine().Split(' ').ToArray();
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                Person person = new Person(name, age);

                sortedSet.Add(person);
                hashSet.Add(person);
            }
            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);           
        }
    }
}
