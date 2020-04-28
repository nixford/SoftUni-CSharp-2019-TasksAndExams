using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            List<string> commandList = new List<string>();
            List<int> positiveNumbersList = new List<int>();
            int sumNegative = 0;
            int sumPositive = 0;

            while (command != "End")
            {                
                commandList = command.Split().ToList();
                if (commandList[0] == "Switch")
                {
                    if (int.Parse(commandList[1]) >= 0 && int.Parse(commandList[1]) < numbers.Length)
                    {
                        numbers[int.Parse(commandList[1])] = numbers[int.Parse(commandList[1])] * -1;
                    }
                }

                if (commandList[0] == "Change")
                {
                    if (int.Parse(commandList[1]) >= 0 && int.Parse(commandList[1]) < numbers.Length)
                    {
                        numbers[int.Parse(commandList[1])] = int.Parse(commandList[2]);
                    }
                }

                if (commandList[0] == "Sum" && commandList[1] == "Negative")
                {                    
                    foreach (var number in numbers)
                    {                        
                        if (number < 0)
                        {
                            sumNegative = sumNegative + number;
                        }
                    }
                    Console.WriteLine(sumNegative);
                }

                if (commandList[0] == "Sum" && commandList[1] == "Positive")
                {                                      
                    foreach (var number in numbers)
                    {                        
                        if (number >= 0)
                        {
                            sumPositive = sumPositive + number;                            
                        }
                    }
                    Console.WriteLine(sumPositive);
                }

                if (commandList[0] == "Sum" && commandList[1] == "All")
                {
                    int sumAll = numbers.Sum();
                    Console.WriteLine(sumAll);
                }
                command = Console.ReadLine();
            }
            foreach (var number in numbers)
            {
                if (number >= 0)
                {                    
                    positiveNumbersList.Add(number);
                }
            }
            Console.WriteLine(string.Join(" ", positiveNumbersList));
        }
    }
}
