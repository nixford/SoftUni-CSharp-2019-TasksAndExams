using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

namespace Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nsx = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int digitN = nsx[0];
            int digitS = nsx[1];
            int digitX = nsx[2];
            int[] numbersN = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>();

            if (numbersN.Length >= digitN)
            {
                for (int i = 0; i < digitN; i++)
                {
                    stack.Push(numbersN[i]);
                }
            }
            else
            {
                for (int i = 0; i < numbersN.Length; i++)
                {
                    stack.Push(numbersN[i]);
                }
            }

            for (int i = 0; i < digitS && stack.Any(); i++)
            {
                stack.Pop();
            }

            if (stack.Any())
            {
                if (stack.Contains(digitX))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    stack.OrderByDescending(a => a);                    
                    Console.WriteLine(stack.Peek());
                }
            }
            else
            {
                Console.WriteLine("0");
            }            
        }
    }
}
