using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    class Program
    {
        static void Main(string[] args)
        {            
            List<string> itemList = Console.ReadLine()
                    .Split(new string[] { ", " },
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Craft!")
            {
                string[] commandLine = command
                    .Split(new string[] { " - " }, 
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (commandLine[0] == "Collect")
                {
                    string item = commandLine[1];
                    if (!itemList.Contains(item))
                    {
                        itemList.Add(item);
                    }
                }
                else if (commandLine[0] == "Drop")
                {
                    string item = commandLine[1];
                    if (itemList.Contains(item))
                    {
                        itemList.Remove(item);
                    }
                }
                else if (commandLine[0] == "Combine Items")
                {
                    string[] items = commandLine[1].Split(':').ToArray();
                    string oldItem = items[0];
                    string newItem = items[1];
                    if (itemList.Contains(oldItem))
                    {
                        int index = itemList.IndexOf(oldItem);
                        itemList.Insert(index + 1, newItem);
                    }
                }
                else if (commandLine[0] == "Renew")
                {
                    string item = commandLine[1];
                    if (itemList.Contains(item))
                    {
                        itemList.Remove(item);
                        itemList.Add(item);
                    }
                }
            }
            Console.WriteLine(string.Join(", ", itemList));
        }
    }
}
