using System;
using System.Collections.Generic;
using System.Linq;

namespace Advanced_Exam___22_Feb_2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputOne = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            Queue<int> firstBox = new Queue<int>(inputOne);

            int[] inputTwo = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            Stack<int> secondBox = new Stack<int>(inputTwo);

            List<int> summedItemsCollection = new List<int>();

            while (firstBox.Any() && secondBox.Any())
            {
                int currFirstItem = firstBox.Peek();
                int currSecondItem = secondBox.Peek();

                if ((currFirstItem + currSecondItem) % 2 == 0)
                {
                    summedItemsCollection.Add(firstBox.Dequeue() + secondBox.Pop());
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }

            if (!firstBox.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }
            if (!secondBox.Any())
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (summedItemsCollection.Sum() >= 100)
            {
                int result = summedItemsCollection.Sum();
                Console.WriteLine($"Your loot was epic! Value: {result}");
            }
            else
            {
                int result = summedItemsCollection.Sum();
                Console.WriteLine($"Your loot was poor... Value: {result}");
            }
        }
    }
}
