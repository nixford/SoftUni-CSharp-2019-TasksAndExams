using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<string> command = Console.ReadLine().Split(' ').ToList();

            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    inputList.Add(int.Parse(command[1]));
                }
                if (command[0] == "Remove")
                {
                    inputList.Remove(int.Parse(command[1]));
                }
                if (command[0] == "RemoveAt")
                {
                    inputList.RemoveAt(int.Parse(command[1]));
                }
                if (command[0] == "Insert")
                {
                    inputList.Insert(int.Parse(command[2]), int.Parse(command[1]));
                }
                if (command[0] == "Contains")
                {
                    if (inputList.Contains(int.Parse(command[1])))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                if (command[0] == "PrintEven")
                {
                    for (int i = 0; i < inputList.Count; i++)
                    {
                        if (inputList[i] % 2 == 0)
                        {
                            Console.Write(inputList[i] + " ");
                        }
                    }
                    Console.WriteLine();
                }
                if (command[0] == "PrintOdd")
                {
                    for (int i = 0; i < inputList.Count; i++)
                    {
                        if (inputList[i] % 2 != 0)
                        {
                            Console.Write(inputList[i] + " ");
                        }
                    }
                    Console.WriteLine();
                }
                if (command[0] == "GetSum")
                {
                    Console.WriteLine(inputList.Sum());
                }
                if (command[0] == "Filter")
                {
                    if (command[1] == "<")
                    {                        
                        for (int i = 0; i < inputList.Count; i++)
                        {
                            if (inputList[i] < int.Parse(command[2]))
                            {
                                Console.Write(inputList[i] + " ");
                            }
                        }
                        Console.WriteLine();
                    }
                    else if (command[1] == "<=")
                    {                        
                        for (int i = 0; i < inputList.Count; i++)
                        {
                            if (inputList[i] <= int.Parse(command[2]))
                            {
                                Console.Write(inputList[i] + " ");
                            }
                        }
                        Console.WriteLine();
                    }
                    else if (command[1] == ">")
                    {                        
                        for (int i = 0; i < inputList.Count; i++)
                        {
                            if (inputList[i] > int.Parse(command[2]))
                            {
                                Console.Write(inputList[i] + " ");
                            }
                        }
                        Console.WriteLine();
                    }
                    else if (command[1] == ">=")
                    {                        
                        for (int i = 0; i < inputList.Count; i++)
                        {
                            if (inputList[i] >= int.Parse(command[2]))
                            {
                                Console.Write(inputList[i] + " ");
                            }
                        }
                        Console.WriteLine();
                    }
                }
                command = Console.ReadLine().Split(' ').ToList();
            }
            if (command[0] == "Add" || command[0] == "Remove" || command[0] == "RemoveAt" || command[0] == "Insert")
            {
                Console.WriteLine(string.Join(" ", inputList));
            }
        }
    }
}
