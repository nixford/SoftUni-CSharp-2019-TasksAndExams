using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Manager_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Dictionary<string, List<int>> dataBase = new Dictionary<string, List<int>>();

            while ((input = Console.ReadLine()) != "Results")
            {
                string[] inputLine = input.Split(':').ToArray();

                if (inputLine[0] == "Add")
                {
                    string name = inputLine[1];
                    int health = int.Parse(inputLine[2]);
                    int energy = int.Parse(inputLine[3]);

                    if (!dataBase.ContainsKey(name))
                    {
                        dataBase.Add(name, new List<int>());
                        dataBase[name].Add(health);
                        dataBase[name].Add(energy);
                    }
                    else
                    {
                        dataBase[name][0] += health;
                    }
                }
                else if (inputLine[0] == "Attack")
                {
                    string attackerName = inputLine[1];
                    string defenderName = inputLine[2];
                    int damage = int.Parse(inputLine[3]);

                    if (dataBase.ContainsKey(attackerName) && dataBase.ContainsKey(defenderName))
                    {
                        dataBase[defenderName][0] -= damage;
                        if (dataBase[defenderName][0] <= 0)
                        {
                            Console.WriteLine($"{defenderName} was disqualified!");
                            dataBase.Remove(defenderName);
                        }

                        dataBase[attackerName][1] -= 1;
                        if (dataBase[attackerName][1] <= 0)
                        {
                            Console.WriteLine($"{attackerName} was disqualified!");
                            dataBase.Remove(attackerName);
                        }
                    }
                }
                else if (inputLine[0] == "Delete")
                {
                    string name = inputLine[1];
                    if (name != "All")
                    {
                        dataBase.Remove(name);
                    }
                    else
                    {
                        dataBase.Clear();
                    }                    
                }
            }

            Console.WriteLine($"People count: {dataBase.Keys.Count}");
            foreach (var kvp in dataBase.OrderByDescending(v => v.Value[0]).ThenBy(k => k.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value[0]} - {kvp.Value[1]}");
            }
        }
    }
}
