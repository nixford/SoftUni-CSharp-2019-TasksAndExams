using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hero_Recruitment
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Dictionary<string, List<string>> dataBase = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputLine = input
                    .Split(new string[] { " " },
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (inputLine[0] == "Enroll")
                {
                    string heroName = inputLine[1];
                    if (!dataBase.ContainsKey(heroName))
                    {
                        dataBase.Add(heroName, new List<string>());
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} is already enrolled.");
                    }
                }
                else if (inputLine[0] == "Learn")
                {
                    string heroName = inputLine[1];
                    string spellName = inputLine[2];
                    if (!dataBase.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                    else
                    {
                        if (!dataBase[heroName].Contains(spellName))
                        {
                            dataBase[heroName].Add(spellName);
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} has already learnt {spellName}.");
                        }
                    }
                }
                else if (inputLine[0] == "Unlearn")
                {
                    string heroName = inputLine[1];
                    string spellName = inputLine[2];
                    if (!dataBase.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                    else
                    {
                        if (dataBase[heroName].Contains(spellName))
                        {
                            dataBase[heroName].Remove(spellName);
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} doesn't know {spellName}.");
                        }
                    }
                }
            }            
            Console.WriteLine("Heroes:");
            foreach (var kvp in dataBase.OrderByDescending(c => c.Value.Count).ThenBy(k => k.Key))
            {
                Console.WriteLine($"== {kvp.Key}: " + string.Join(", ", kvp.Value));                
            }
        }
    }
}
