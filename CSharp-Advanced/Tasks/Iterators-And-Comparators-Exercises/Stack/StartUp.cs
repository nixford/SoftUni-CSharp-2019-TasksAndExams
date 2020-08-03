using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            CustomStack<int> stack = new CustomStack<int>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] splitedInput = input.Split(" ", 2).ToArray();
                string command = splitedInput[0];

                if (command == "Push")
                {
                    int[] numbers = splitedInput[1]
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                    stack.Push(numbers);                                
                }
                else if (command == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (Exception ex)
                    {                       
                        Console.WriteLine(ex.Message);
                    }                    
                }
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var number in stack)
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}
