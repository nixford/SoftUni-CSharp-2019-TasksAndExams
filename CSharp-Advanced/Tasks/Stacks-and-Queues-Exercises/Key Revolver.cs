using System;
using System.Collections.Generic;
using System.Linq;

namespace Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int valueIntelligence = int.Parse(Console.ReadLine());

            Stack<int> bulletsStack = new Stack<int>(bullets.AsEnumerable());
            Queue<int> locksQueue = new Queue<int>(locks.AsQueryable());

            int currGunBarrelSize = gunBarrelSize;
            int totalBulletsPrice = 0;

            while (bulletsStack.Any() && locksQueue.Any())
            {                
                if (bulletsStack.Peek() <= locksQueue.Peek())
                {
                    Console.WriteLine("Bang!");
                    bulletsStack.Pop();
                    locksQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                    bulletsStack.Pop();
                }
                currGunBarrelSize--;
                totalBulletsPrice += bulletPrice;

                if (currGunBarrelSize == 0 && bulletsStack.Any())
                {
                    Console.WriteLine("Reloading!");
                    currGunBarrelSize = gunBarrelSize;
                }
            }

            if (bulletsStack.Any() == false && locksQueue.Any() == true)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
            else
            {
                Console.WriteLine($"“{bulletsStack.Count()} bullets left. Earned ${valueIntelligence - totalBulletsPrice}");
            }
        }
    }
}
