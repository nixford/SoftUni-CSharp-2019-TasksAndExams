using System;
using System.Collections.Generic;
using System.Linq;

namespace Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] bottles = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> cupsCapacityQueue = new Queue<int>(cupsCapacity.AsQueryable());
            Stack<int> bottlesStack = new Stack<int>(bottles.AsQueryable());

            int wastedWater = 0;
            bool currBottleIsEnough = true;            
            int diff = 0;
           

            while (cupsCapacityQueue.Any() && bottlesStack.Any())
            {               

                if (bottlesStack.Peek() >= cupsCapacityQueue.Peek() && currBottleIsEnough == true)
                {
                    wastedWater += bottlesStack.Pop() - cupsCapacityQueue.Dequeue();
                }
                else
                {
                    currBottleIsEnough = false;                    
                }

                if (currBottleIsEnough == false)
                {
                    diff = cupsCapacityQueue.Peek() - bottlesStack.Pop();

                    while (true)
                    {                        
                        if (bottlesStack.Peek() < diff)
                        {
                            diff -= bottlesStack.Pop();
                        }
                        else
                        {
                            wastedWater += bottlesStack.Peek() - diff;
                            diff -= bottlesStack.Pop();
                        }

                        if (diff <= 0)
                        {
                            break;
                        }
                    }
                    cupsCapacityQueue.Dequeue();
                    currBottleIsEnough = true;
                }
            }

            if (cupsCapacityQueue.Any() == false)
            {
                Console.Write("Bottles: ");
                while (bottlesStack.Any())
                {
                    if (bottlesStack.Count == 1)
                    {
                        Console.Write(bottlesStack.Pop());
                    }
                    else
                    {
                        Console.Write(bottlesStack.Pop() + " ");
                    }                    
                }
                Console.WriteLine();
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else
            {
                Console.Write("Cups: ");
                while (cupsCapacityQueue.Any())
                {                    
                    if (cupsCapacityQueue.Count == 1)
                    {
                        Console.Write(cupsCapacityQueue.Dequeue());
                    }
                    else
                    {
                        Console.Write(cupsCapacityQueue.Dequeue() + " ");
                    }
                }
                Console.WriteLine();
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
        }
    }
}
