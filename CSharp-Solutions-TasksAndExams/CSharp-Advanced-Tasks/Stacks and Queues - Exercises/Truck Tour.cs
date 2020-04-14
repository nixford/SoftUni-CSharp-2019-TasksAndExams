using System;
using System.Collections.Generic;
using System.Linq;

namespace Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int petrolPompsNumber = int.Parse(Console.ReadLine());
            Queue<int[]> pumps = new Queue<int[]>();
            int cnt = 0;

            for (int i = 0; i < petrolPompsNumber; i++)
            {
                int[] currPump = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                 
                pumps.Enqueue(currPump);
            }

            while (true)
            {
                int fuelAmount = 0;
                bool foundPoint = true;

                for (int i = 0; i < petrolPompsNumber; i++)
                {
                    int[] currentPump = pumps.Dequeue();
                    fuelAmount += currentPump[0];

                    if (fuelAmount < currentPump[1 ])
                    {
                        foundPoint = false;
                    }

                    fuelAmount -= currentPump[1];

                    pumps.Enqueue(currentPump);
                }

                if (foundPoint)
                {
                    break;
                }

                cnt++;

                pumps.Enqueue(pumps.Dequeue());
            }
            Console.WriteLine(cnt);
        }
    }
}
