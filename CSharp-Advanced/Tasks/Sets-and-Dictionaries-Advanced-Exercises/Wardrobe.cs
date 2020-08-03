using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class Wardrobe
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> dataBase =
                new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < number; i++)
            {
                string[] commandLine = Console.ReadLine()
                    .Split(new string[] { " -> ", "," }, 
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string collor = commandLine[0];

                for (int j = 1; j < commandLine.Length; j++)
                {
                    string currCloath = commandLine[j];
                    if (!dataBase.ContainsKey(collor))
                    {
                        dataBase.Add(collor, new Dictionary<string, int>());
                        if (!dataBase[collor].ContainsKey(currCloath))
                        {
                            dataBase[collor].Add(currCloath, 1);
                        }
                        else
                        {
                            dataBase[collor][currCloath]++;
                        }
                    }
                    else
                    {
                        if (!dataBase[collor].ContainsKey(currCloath))
                        {
                            dataBase[collor].Add(currCloath, 1);
                        }
                        else
                        {
                            dataBase[collor][currCloath]++;
                        }
                    }
                }                
            }
            string[] input = Console.ReadLine().Split().ToArray();
            string collorFound = input[0];
            string cloathFound = input[1];

            foreach (var kvp in dataBase)
            {
                Console.WriteLine($"{kvp.Key} clothes:");
                foreach (var (cloat, count) in kvp.Value)
                {
                    if (kvp.Key == collorFound && cloat == cloathFound)
                    {
                        Console.WriteLine($"* {cloat} - {count} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloat} - {count}");
                    }                    
                }
            }
        }
    }
}
