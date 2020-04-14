using System;
using System.Collections.Generic;
using System.Linq;

namespace Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int boxCapacity = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(clothes);           
            int totalBoxNumber = 1;
            int sum = 0;

            while (stack.Count > 0)
            {
                sum += stack.Peek();
                if (sum <= boxCapacity)
                {
                    stack.Pop();
                }
                else
                {
                    totalBoxNumber++;
                    sum = 0;
                }

            }
            Console.WriteLine(totalBoxNumber);            
        }
    }
}
