using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treasure_Hunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> initialTreasureList = Console.ReadLine().Split('|').ToList();
            string command = Console.ReadLine();
            List<string> commandList = new List<string>();
            double totalLength = 0;
            List<string> stealtItems = new List<string>();

            while (command != "Yohoho!")
            {
                commandList = command.Split(' ').ToList();

                if (commandList[0] == "Loot")
                {
                    for (int i = 1; i < commandList.Count; i++)
                    {
                        if (!initialTreasureList.Contains(commandList[i]))
                        {
                            initialTreasureList.Insert(0, commandList[i]);
                        }
                    }
                }

                if (commandList[0] == "Drop")
                {
                    int index = int.Parse(commandList[1]);
                    if (index >= 0 && index < initialTreasureList.Count)
                    {
                        string removedItem = initialTreasureList[index];
                        initialTreasureList.RemoveAt(index);
                        initialTreasureList.Add(removedItem);
                    }                    
                }

                if (commandList[0] == "Steal")
                {
                    int count = int.Parse(commandList[1]);
                    int startIndex = initialTreasureList.Count - count;

                    if (count < initialTreasureList.Count && count + startIndex < initialTreasureList.Count)
                    {                       
                        for (int i = startIndex; i < initialTreasureList.Count; i++)
                        {
                            stealtItems.Add(initialTreasureList[i]);
                        }              
                        Console.WriteLine(string.Join(", ", stealtItems));
                        initialTreasureList.RemoveRange(startIndex, count);                        
                    }
                    else if (count < initialTreasureList.Count && count + startIndex >= initialTreasureList.Count)
                    {
                        for (int i = startIndex; i < initialTreasureList.Count; i++)
                        {
                            stealtItems.Add(initialTreasureList[i]);
                        }
                        Console.WriteLine(string.Join(", ", stealtItems));
                        initialTreasureList.RemoveRange(startIndex, (initialTreasureList.Count - startIndex));                       
                    }
                    else
                    {
                        Console.WriteLine(string.Join(", ", initialTreasureList));
                        initialTreasureList = new List<string>();
                    }                    
                    stealtItems = new List<string>();
                }
                command = Console.ReadLine();
            }

            foreach (var item in initialTreasureList)
            {
                totalLength = totalLength + item.Length;
            }
            double averageGain = totalLength / initialTreasureList.Count;

            if (initialTreasureList.Count <= 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
            }
        }
    }
}
