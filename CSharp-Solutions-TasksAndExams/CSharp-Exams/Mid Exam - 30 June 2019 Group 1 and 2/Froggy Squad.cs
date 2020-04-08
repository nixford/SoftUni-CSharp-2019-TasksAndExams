using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Froggy_Squad
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> frogsNames = Console.ReadLine().Split(' ').ToList();
            string command = Console.ReadLine();
            List<string> commandList = command.Split().ToList();

            while (true)
            {
                commandList = command.Split().ToList();
                if (commandList[0] == "Join")
                {
                    frogsNames.Add(commandList[1]);
                }
                if (commandList[0] == "Jump")
                {
                    if (int.Parse(commandList[2]) >= 0 && int.Parse(commandList[2]) < frogsNames.Count)
                    {
                        frogsNames.Insert(int.Parse(commandList[2]), commandList[1]);
                    }
                }
                if (commandList[0] == "Dive")
                {
                    if (int.Parse(commandList[1]) >= 0 && int.Parse(commandList[1]) < frogsNames.Count)
                    {
                        frogsNames.RemoveAt(int.Parse(commandList[1]));
                    }
                }
                if (commandList[0] == "First")
                {
                    for (int i = 0; i < frogsNames.Count; i++)
                    {
                        if (i <= int.Parse(commandList[1]))
                        {
                            Console.Write(frogsNames[i] + " ");
                        }
                    }
                    Console.WriteLine();
                }
                if (commandList[0] == "Last")
                {
                    for (int i = 0; i < frogsNames.Count; i++)
                    {
                        if (i > ((frogsNames.Count - 1) - int.Parse(commandList[1])) && i < frogsNames.Count)
                        {
                            Console.Write(frogsNames[i] + " ");
                        }
                    }
                    Console.WriteLine();
                }
                if (commandList[0] == "Print" && commandList[1] == "Normal")
                {
                    Console.WriteLine("Frogs: " + string.Join(" ", frogsNames));
                    break;
                }

                if (commandList[0] == "Print" && commandList[1] == "Reversed")
                {
                    frogsNames.Reverse();
                    Console.WriteLine("Frogs: " + string.Join(" ", frogsNames));
                    break;
                }
                command = Console.ReadLine();
            }
        }
    }
}