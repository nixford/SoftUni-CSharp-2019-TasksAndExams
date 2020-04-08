using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Friendlist_Maintenance
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] friednList = Console.ReadLine().Split(',').Select(a => a.Trim()).ToArray();
            string commands = Console.ReadLine();
            string[] commandList = commands.Split().ToArray();

            int blackListedCount = 0;
            int lostNamesCount = 0;

            while (commands != "Report")
            {
                commandList = commands.Split().ToArray();

                if (commandList[0] == "Blacklist")
                {
                    if (friednList.Contains(commandList[1]))
                    {
                        int index = Array.IndexOf(friednList, commandList[1]);
                        Console.WriteLine($"{commandList[1]} was blacklisted.");
                        friednList[index] = "Blacklisted";
                        blackListedCount++;
                    }
                    else
                    {
                        Console.WriteLine($"{commandList[1]} was not found.");
                    }
                }

                if (commandList[0] == "Error")
                {
                    if (friednList[int.Parse(commandList[1])] != "Blacklisted" &&
                        friednList[int.Parse(commandList[1])] != "Lost")
                    {
                        string name = friednList[int.Parse(commandList[1])];
                        friednList[int.Parse(commandList[1])] = "Lost";
                        Console.WriteLine($"{name} was lost due to an error.");
                        lostNamesCount++;
                    }
                }

                if (commandList[0] == "Change")
                {
                    if (int.Parse(commandList[1]) >= 0 && int.Parse(commandList[1]) < friednList.Length)
                    {
                        string newName = commandList[2];
                        string oldName = friednList[int.Parse(commandList[1])];
                        friednList[int.Parse(commandList[1])] = newName;
                        Console.WriteLine($"{oldName} changed his username to {newName}.");
                    }
                }
                commands = Console.ReadLine();
            }
            Console.WriteLine($"Blacklisted names: {blackListedCount}");
            Console.WriteLine($"Lost names: {lostNamesCount}");
            Console.WriteLine(string.Join(" ", friednList));
        }
    }
}
