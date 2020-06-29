using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputBombEffect = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> effectBomb = new Queue<int>(inputBombEffect);

            int[] inputCasingsBomb = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> casingsBomb = new Stack<int>(inputCasingsBomb);

            int daturaBombsCount = 0;
            int cherryBombsCount = 0;
            int smokeDecoyBombsCount = 0;
            bool IsFullBombPuch = false;

            while (effectBomb.Any() && casingsBomb.Any())
            {
                int currBombEffect = effectBomb.Peek();
                int currBombCaseings = casingsBomb.Peek();

                if (currBombEffect + currBombCaseings == 40)
                {
                    daturaBombsCount++;
                    effectBomb.Dequeue();
                    casingsBomb.Pop();
                }
                else if (currBombEffect + currBombCaseings == 60)
                {
                    cherryBombsCount++;
                    effectBomb.Dequeue();
                    casingsBomb.Pop();
                }
                else if (currBombEffect + currBombCaseings == 120)
                {
                    smokeDecoyBombsCount++;
                    effectBomb.Dequeue();
                    casingsBomb.Pop();
                }
                else
                {
                    int currElementBombCasing = casingsBomb.Pop();
                    currElementBombCasing -= 5;
                    casingsBomb.Push(currElementBombCasing);
                }


                if (daturaBombsCount >= 3 && 
                    cherryBombsCount >= 3 && 
                    smokeDecoyBombsCount >= 3)
                {
                    IsFullBombPuch = true;
                    break;
                }
            }

            if (IsFullBombPuch == true)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (!effectBomb.Any())
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                List<int> temp = new List<int>(effectBomb);
                Console.WriteLine($"Bomb Effects: " + string.Join(", ", temp));
            }

            if (!casingsBomb.Any())
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                List<int> temp = new List<int>(casingsBomb);
                Console.WriteLine($"Bomb Casings: " + string.Join(", ", temp));
            }

            Console.WriteLine($"Cherry Bombs: {cherryBombsCount}");
            Console.WriteLine($"Datura Bombs: {daturaBombsCount}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyBombsCount}");
        }
    }
}
