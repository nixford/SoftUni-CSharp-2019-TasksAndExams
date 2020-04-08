using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> initialList = Console.ReadLine().Split('!').ToList();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Go Shopping!")
            {
                string[] commandLine = command.Split(' ').ToArray();

                if (commandLine[0] == "Urgent")
                {
                    string item = commandLine[1];
                    if (!initialList.Contains(item))
                    {
                        initialList.Insert(0, item);
                    }                    
                }
                else if (commandLine[0] == "Unnecessary")
                {
                    string item = commandLine[1];
                    if (initialList.Contains(item))
                    {
                        initialList.Remove(item);
                    }
                }
                else if (commandLine[0] == "Correct")
                {
                    string oldItem = commandLine[1];
                    string newItem = commandLine[2];
                    if (initialList.Contains(oldItem))
                    {
                        int index = initialList.IndexOf(oldItem);
                        initialList[index] = newItem;
                    }
                }
                else if (commandLine[0] == "Rearrange")
                {
                    string item = commandLine[1];
                    if (initialList.Contains(item))
                    {
                        initialList.Remove(item);
                        initialList.Add(item);
                    }
                }
            }
            Console.WriteLine(string.Join(", ", initialList));
        }
    }
}
