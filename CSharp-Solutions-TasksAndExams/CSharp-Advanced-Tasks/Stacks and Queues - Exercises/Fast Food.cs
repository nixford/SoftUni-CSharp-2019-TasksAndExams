using System;
using System.Collections.Generic;
using System.Linq;

namespace Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodNumber = int.Parse(Console.ReadLine());
            int[] ordersList = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Queue<int> orders = new Queue<int>(ordersList);
            bool isEnough = true;

            Console.WriteLine(orders.Max());

            for (int i = 0; i < ordersList.Length; i++)
            {
                if (foodNumber >= ordersList[i])
                {
                    foodNumber -= ordersList[i];
                    orders.Dequeue();
                }
                else
                {
                    isEnough = false;
                    break;
                }
                
            }
            if (isEnough == true)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: " + string.Join(" ", orders));
            }
        }
    }
}
