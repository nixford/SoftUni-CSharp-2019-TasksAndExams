using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputLine = Console.ReadLine()
                .Split(new string[] { " " }, 
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Stack<string> result = new Stack<string>(inputLine.Reverse());           

            while (result.Count > 1)
            {
                int firstNumber = int.Parse(result.Pop());
                string operation = result.Pop();
                int secondNumber = int.Parse(result.Pop());

                if (operation == "+")
                {
                    int sum = firstNumber + secondNumber;
                    result.Push(sum.ToString());
                }
                else
                {
                    int sum = firstNumber - secondNumber;
                    result.Push(sum.ToString());
                }
            }
            Console.WriteLine(result.Peek());
        }
    }
}
