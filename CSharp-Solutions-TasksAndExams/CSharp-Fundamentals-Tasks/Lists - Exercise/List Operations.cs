using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string command = Console.ReadLine();

            while (command != "End")
            {
                List<string> commandList = command.Split(' ').ToList();                
                if (commandList[0] == "Add")
                {
                    numbersList.Add(int.Parse(commandList[1]));
                }
                else if (commandList[0] == "Insert")
                {
                    if (int.Parse(commandList[2]) <= numbersList.Count)
                    {
                        numbersList.Insert(int.Parse(commandList[2]), int.Parse(commandList[1]));
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }                    
                }
                else if (commandList[0] == "Remove")
                {                    
                    if (int.Parse(commandList[1]) <= numbersList.Count)
                    {
                        numbersList.RemoveAt(int.Parse(commandList[1]));
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (commandList[0] == "Shift" && commandList[1] == "left")
                {
                    for (int i = 0; i < int.Parse(commandList[2]); i++)
                    {
                        int firstNum = numbersList[0];
                        numbersList.Remove(numbersList[0]);
                        numbersList.Add(firstNum);
                    }
                }
                else if (commandList[0] == "Shift" && commandList[1] == "right")
                {
                    for (int i = 0; i < int.Parse(commandList[2]); i++)
                    {
                        int lastNum = numbersList[numbersList.Count - 1];
                        numbersList.RemoveAt(numbersList.Count - 1);
                        numbersList.Insert(0, lastNum);
                    }
                }                
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", numbersList));
        }
    }
}
