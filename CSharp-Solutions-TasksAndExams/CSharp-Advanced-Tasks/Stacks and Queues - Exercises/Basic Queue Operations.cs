using System;
using System.Linq;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;

namespace Basic_Queue_Operations
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

            Queue<int> queue = new Queue<int>();

            if (numbersN.Length >= digitN)
            {
                for (int i = 0; i < digitN; i++)
                {
                    queue.Enqueue(numbersN[i]);
                }
            }
            else
            {
                for (int i = 0; i < numbersN.Length; i++)
                {
                    queue.Enqueue(numbersN[i]);
                }
            }

            for (int i = 0; i < digitS && queue.Any(); i++)
            {
                queue.Dequeue();
            }

            if (queue.Any())
            {
                if (queue.Contains(digitX))
                {
                    Console.WriteLine("true");
                }
                else
                {                    
                    Console.WriteLine(queue.Min());
                }
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }    
}
