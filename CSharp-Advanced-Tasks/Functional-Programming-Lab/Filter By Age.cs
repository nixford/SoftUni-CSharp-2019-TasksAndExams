using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Filter_By_Age
{
    class Program
    {
        public class People
        {
            public string Name { get; set; }

            public int Age { get; set; }
        }
        static void Main(string[] args)
        {
            int totalPeople = int.Parse(Console.ReadLine());

            List<People> people = new List<People>();

            for (int i = 0; i < totalPeople; i++)
            {
                var currPeopleData = Console.ReadLine().Split(", ");

                var currPeople = new People
                {
                    Name = currPeopleData[0],
                    Age = int.Parse(currPeopleData[1])
                };
                people.Add(currPeople);
            }

            string filterText = Console.ReadLine();
            int ageToFilter = int.Parse(Console.ReadLine());

            //if (filter == "older")
            //{
            //    people = people.where(c => c.age >= agetofilter).tolist();                
            //}
            //else if (filter == "younger")
            //{
            //    people = people.where(c => c.age <= agetofilter).tolist();                
            //}

            Func<People, bool> filterFunc = filterText switch
            {
                "older" => c => c.Age >= ageToFilter,
                "younger" => c => c.Age < ageToFilter,
                _ => c => true
            };

            var outputFormat = Console.ReadLine();

            Func<People, string> outputFunc = outputFormat switch
            {
                "name age" => c => $"{c.Name} - {c.Age}",
                "name" => c => c.Name,
                "age" => c => $"{c.Age}",
                _ => null
            };

            people
                .Where(filterFunc)
                .Select(outputFunc)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
