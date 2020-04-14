using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int lineNumber = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < lineNumber; i++)
            {
                string[] currLine = Console.ReadLine()
                    .Split(' ')                    
                    .ToArray();

                if (currLine[0] == "1")
                {
                    stack.Push(int.Parse(currLine[1]));
                }
                else if (currLine[0] == "2")
                {
                    if (stack.Any())
                    {
                        stack.Pop();
                    }                   
                }
                else if (currLine[0] == "3")
                {
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Max());
                    }                    
                }
                else if (currLine[0] == "4")
                {
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Min());
                    }                    
                }
            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
