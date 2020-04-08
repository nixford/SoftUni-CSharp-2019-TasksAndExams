using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_Sessions
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Dictionary<string, List<string>> dataBase = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputLine = input
                    .Split(new string[] { "-", ">" }
                    , StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (inputLine[0] == "Add")
                {
                    string road = inputLine[1];
                    string racer = inputLine[2];
                    if (!dataBase.ContainsKey(road))
                    {
                        dataBase.Add(road, new List<string>());
                        dataBase[road].Add(racer);
                    }
                    else
                    {
                        dataBase[road].Add(racer);
                    }
                }
                else if (inputLine[0] == "Move")
                {
                    string currentRoad = inputLine[1];
                    string racer = inputLine[2];
                    string nextRoad = inputLine[3];
                    if (dataBase[currentRoad].Contains(racer))
                    {
                        dataBase[currentRoad].Remove(racer);
                        dataBase[nextRoad].Add(racer);
                    }
                }
                else if (inputLine[0] == "Close")
                {
                    string road = inputLine[1];
                    if (dataBase.ContainsKey(road))
                    {
                        dataBase.Remove(road);
                    }
                }
            }
            Console.WriteLine("Practice sessions:");
            foreach (var kvp in dataBase.OrderByDescending(v => v.Value.Count).ThenBy(k => k.Key))
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (var racer in kvp.Value)
                {
                    Console.WriteLine($"++{racer}");
                }
            }
        }
    }
}
