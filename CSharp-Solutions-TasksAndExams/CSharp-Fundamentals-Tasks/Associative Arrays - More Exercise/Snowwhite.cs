using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {            
            string[] inputLine = Console.ReadLine()
                .Split(new string[] { "<:>" }, 
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            SortedDictionary<string, SortedDictionary<string, long>> dataBase = 
                new SortedDictionary<string, SortedDictionary<string, long>>();

            string name = string.Empty;
            string hatCollor = string.Empty;
            long physics = 0;

            while (inputLine[0] != "Once upon a time")
            {
                name = inputLine[0];
                hatCollor = inputLine[1];
                physics = long.Parse(inputLine[2]);

                if (!dataBase.ContainsKey(name))
                {
                    dataBase.Add(name, new SortedDictionary<string, long>());
                    dataBase[name].Add(hatCollor, physics);                    
                }
                else if (dataBase.ContainsKey(name) && !dataBase[name].ContainsKey(hatCollor))
                {
                    dataBase[name].Add(hatCollor, physics);
                }
                else if (dataBase.ContainsKey(name) && dataBase[name].ContainsKey(hatCollor))
                {
                    if (dataBase[name][hatCollor] < physics)
                    {
                        dataBase[name][hatCollor] = physics;
                    }                   
                }

                inputLine = Console.ReadLine()
                .Split(new string[] { "<:>" },
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }                       

            foreach (var item in dataBase
                .OrderByDescending(x => x.Value.Values.Sum())
                .ThenByDescending(a => a.Value.Keys.Count())
                .ToDictionary(x => x.Key, x => x.Value.OrderByDescending(y => y.Value).ToDictionary(y => y.Key, y => y.Value)))
            {                
                foreach (var kvp in item.Value)
                {
                    Console.WriteLine($"({kvp.Key}) {item.Key} <-> {kvp.Value}");
                }
            }
        }
    }
}
