using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputLine = Console.ReadLine()
                .Split(new string[] { " -> "  }, 
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            Dictionary<string, Dictionary<string, int>> dataBaseDict = 
                new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> orderedDict = new Dictionary<string, int>();

            string name = inputLine[0];
            string contest = inputLine[1];
            int points = int.Parse(inputLine[2]);
            int count = 0;

            while (inputLine[0] != "no more time")
            {
                name = inputLine[0];
                contest = inputLine[1];
                points = int.Parse(inputLine[2]);

                if (!dataBaseDict.ContainsKey(contest))
                {
                    dataBaseDict.Add(contest, new Dictionary<string, int>());
                    dataBaseDict[contest].Add(name, points);
                }
                else
                {
                    if (!dataBaseDict[contest].ContainsKey(name))
                    {
                        dataBaseDict[contest].Add(name, points);
                    }
                    else // if username is already participating - take the higher score
                    {
                        if (dataBaseDict[contest][name] < points)
                        {
                            dataBaseDict[contest][name] = points;
                        }
                    }
                }
                inputLine = Console.ReadLine()
                .Split(new string[] { " -> " },
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            foreach (var kvp in dataBaseDict)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Keys.Count} participants");
                foreach (var item in kvp.Value.OrderByDescending(v => v.Value).ThenBy(k => k.Key))
                {
                    count++;
                    Console.WriteLine($"{count}. {item.Key} <::> {item.Value}");
                    if (!orderedDict.ContainsKey(item.Key))
                    {
                        orderedDict.Add(item.Key, item.Value);
                    }
                    else
                    {
                        orderedDict[item.Key] += item.Value;
                    }
                }
                count = 0;
            }
            count = 0;                  

            Console.WriteLine("Individual standings:");
            foreach (var kvp in orderedDict.OrderByDescending(v => v.Value).ThenBy(k => k.Key))
            {                
                count++;
                Console.WriteLine($"{count}. {kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
