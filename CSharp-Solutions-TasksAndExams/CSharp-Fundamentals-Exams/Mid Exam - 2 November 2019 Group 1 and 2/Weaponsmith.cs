using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weaponsmith
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputList = Console.ReadLine().Split('|').ToList();
            string command = Console.ReadLine();
            List<string> commandList = command.Split().ToList();
            string output = string.Empty;

            while (command != "Done")
            {
                commandList = command.Split().ToList();
                if (commandList[0] == "Move" && commandList[1] == "Left")
                {
                    int index = int.Parse(commandList[2]);
                    if (index - 1 >= 0 && index < inputList.Count)
                    {
                        string temp = inputList[index];
                        inputList.Remove(inputList[index]);
                        inputList.Insert(index - 1, temp);
                    }                    
                }

                if (commandList[0] == "Move" && commandList[1] == "Right")
                {
                    int index = int.Parse(commandList[2]);
                    if (index >= 0 && index + 1 < inputList.Count)
                    {
                        string temp = inputList[index];
                        inputList.Remove(inputList[index]);
                        inputList.Insert(index + 1, temp);
                    }
                }

                if (commandList[0] == "Check" && commandList[1] == "Even")
                {
                    for (int i = 0; i < inputList.Count; i++)
                    {
                        if (i % 2 == 0)
                        {
                            Console.Write(inputList[i] + " ");
                        }
                    }
                    Console.WriteLine();
                }

                if (commandList[0] == "Check" && commandList[1] == "Odd")
                {
                    for (int i = 0; i < inputList.Count; i++)
                    {
                        if (i % 2 != 0)
                        {
                            Console.Write(inputList[i] + " ");
                        }
                    }
                    Console.WriteLine();
                }
                command = Console.ReadLine();
            }
            foreach (var item in inputList)
            {
                output = output + item;
            }
            Console.WriteLine($"You crafted {output}!");
        }
    }
}
