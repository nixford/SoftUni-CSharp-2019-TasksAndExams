using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(' ').ToArray();
            int toss = int.Parse(Console.ReadLine());

            Queue<string> childrenQueue = new Queue<string>(names);
            
            int currentIndex = 1;

            while (childrenQueue.Count > 1)
            {
                string currName = childrenQueue.Dequeue();                
                if (currentIndex == toss)
                {
                    Console.WriteLine($"Removed {currName}");
                    currentIndex = 0;
                }
                else
                {
                    childrenQueue.Enqueue(currName);
                }
                currentIndex++;
            }
            Console.WriteLine($"Last is {childrenQueue.Dequeue()}");
        }
    }
}
