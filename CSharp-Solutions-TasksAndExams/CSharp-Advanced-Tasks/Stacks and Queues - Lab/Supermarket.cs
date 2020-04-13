using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Supermarket
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            Queue<string> namesQueue = new Queue<string>();

            while (name != "End")
            {
                if (name != "Paid")
                {
                    namesQueue.Enqueue(name);
                }
                else
                {
                    Console.WriteLine(string.Join("\n", namesQueue));
                    namesQueue.Clear();
                }
                name = Console.ReadLine();
            }
            Console.WriteLine($"{namesQueue.Count} people remaining.");
        }
    }
}
