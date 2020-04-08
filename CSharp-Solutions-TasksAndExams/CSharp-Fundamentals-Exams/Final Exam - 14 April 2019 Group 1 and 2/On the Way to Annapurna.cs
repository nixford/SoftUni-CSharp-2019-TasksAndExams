using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace On_the_Way_to_Annapurna
{
    class Program
    {
        static void Main(string[] args)

        {
            string command = string.Empty;

            Dictionary<string, List<string>> dataBase = new Dictionary<string, List<string>>();

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandLine = command
                    .Split(new string[] { ">" }, 
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (commandLine[0] == "Add-" & commandLine.Length == 2)
                {
                    string store = commandLine[1].Remove(commandLine[1].Length - 1, 1);
                    string item = commandLine[2].Remove(commandLine[1].Length - 1, 1);
                    if (!dataBase.ContainsKey(store))
                    {
                        dataBase.Add(store, new List<string>());
                        dataBase[store].Add(item);
                    }
                    else
                    {
                        dataBase[store].Add(item);
                    }
                }
                else if (commandLine[0] == "Add-" & commandLine.Length > 2)
                {
                    string store = commandLine[1].Remove(commandLine[1].Length - 1, 1);
                    if (!dataBase.ContainsKey(store))
                    {
                        dataBase.Add(store, new List<string>());
                        string[] itemsArr = commandLine[2]
                            .Split(new string[] { "," }, 
                            StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
                        for (int i = 0; i < itemsArr.Length; i++)
                        {
                            dataBase[store].Add(itemsArr[i]);
                        }
                    }
                    else
                    {
                        string[] itemsArr = commandLine[2]
                            .Split(new string[] { "," },
                            StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
                        for (int i = 0; i < itemsArr.Length; i++)
                        {
                            dataBase[store].Add(itemsArr[i]);
                        }
                    }
                }
                else if (commandLine[0] == "Remove-")
                {
                    string store = commandLine[1];
                    dataBase.Remove(store);
                }
            }

            Console.WriteLine("Stores list:");
            foreach (var kvp in dataBase.OrderByDescending(v => v.Value.Count).ThenByDescending(k => k.Key))
            {
                Console.WriteLine(kvp.Key);
                foreach (var item in kvp.Value)
                {
                    Console.WriteLine($"<<{item}>>");
                }
            }
        }
    }
}
