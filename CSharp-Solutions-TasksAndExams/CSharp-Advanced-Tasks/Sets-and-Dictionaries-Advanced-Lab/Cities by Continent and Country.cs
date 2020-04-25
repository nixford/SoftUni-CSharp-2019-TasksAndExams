using System;
using System.Collections.Generic;
using System.Linq;

namespace Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> dataBase = 
                new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < number; i++)
            {
                string[] inputLine = Console.ReadLine()
                    .Split()
                    .ToArray();
                string continent = inputLine[0];
                string country = inputLine[1];
                string city = inputLine[2];

                if (!dataBase.ContainsKey(continent))
                {
                    dataBase.Add(continent, new Dictionary<string, List<string>>());
                    if (!dataBase[continent].ContainsKey(country))
                    {
                        dataBase[continent].Add(country, new List<string>());
                        dataBase[continent][country].Add(city);
                    }
                    else
                    {
                        dataBase[continent][country].Add(city);
                    }
                }
                else
                {
                    if (!dataBase[continent].ContainsKey(country))
                    {
                        dataBase[continent].Add(country, new List<string>());
                        dataBase[continent][country].Add(city);
                    }
                    else
                    {
                        dataBase[continent][country].Add(city);
                    }
                }
            }
            foreach (var kvp in dataBase)
            {
                Console.WriteLine($"{kvp.Key}:");
                foreach (var (country, city) in kvp.Value)
                {
                    Console.WriteLine($"{country} -> " + string.Join(", ", city));
                }
            }
        }
    }
}
