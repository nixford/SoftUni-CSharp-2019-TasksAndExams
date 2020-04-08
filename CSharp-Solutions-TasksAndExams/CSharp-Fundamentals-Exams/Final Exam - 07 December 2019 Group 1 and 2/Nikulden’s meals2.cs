using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikulden_s_meals2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Dictionary<string, List<string>> dataBase = new Dictionary<string, List<string>>();
            int unlikedCount = 0;

            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] inputLine = input.Split('-').ToArray();

                if (inputLine[0] == "Like")
                {
                    string guest = inputLine[1];
                    string meal = inputLine[2];
                    if (!dataBase.ContainsKey(guest))
                    {
                        dataBase.Add(guest, new List<string>());
                        if (!dataBase[guest].Contains(meal))
                        {
                            dataBase[guest].Add(meal);
                        }                        
                    }
                    else
                    {
                        if (!dataBase[guest].Contains(meal))
                        {
                            dataBase[guest].Add(meal);
                        }
                    }
                }
                else if (inputLine[0] == "Unlike")
                {
                    string guest = inputLine[1];
                    string meal = inputLine[2];                    

                    if (dataBase.ContainsKey(guest))
                    {
                        if (dataBase[guest].Contains(meal))
                        {
                            dataBase[guest].Remove(meal);
                            unlikedCount++;
                            Console.WriteLine($"{guest} doesn't like the {meal}.");
                        }
                        else
                        {
                            Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                        }                        
                    }
                    else
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }                    
                }
            }

            foreach (var kvp in dataBase.OrderByDescending(v => v.Value.Count()).ThenBy(k => k.Key))
            {
                Console.WriteLine($"{kvp.Key}: " + string.Join(", ", kvp.Value));
            }    
            Console.WriteLine($"Unliked meals: {unlikedCount}");
        }
    }
}
