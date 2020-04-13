using System;
using System.Collections;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

namespace Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string input = string.Empty;
            Stack<int> stack = new Stack<int>(numbers);

            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] inputLine = input.Split().ToArray();

                if (inputLine[0] == "add")
                {
                    int digit1 = int.Parse(inputLine[1]);
                    int digit2 = int.Parse(inputLine[2]);
                    stack.Push(digit1);
                    stack.Push(digit2);
                }
                else if (inputLine[0] == "remove")
                {
                    int countForRemove = int.Parse(inputLine[1]);

                    if (stack.Count >= countForRemove)
                    {
                        for (int i = 0; i < countForRemove; i++)
                        {
                            stack.Pop();
                        }
                    }                    
                }
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
