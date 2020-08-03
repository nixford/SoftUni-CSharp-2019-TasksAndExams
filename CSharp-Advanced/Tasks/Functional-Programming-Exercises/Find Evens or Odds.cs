using System;
using System.Collections.Generic;
using System.Linq;

namespace Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bounds = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string evenOrOdd = Console.ReadLine();

            Predicate<int> predicate = evenOrOdd == "odd" ? 
                new Predicate<int> ((n) => n % 2 != 0) :
                new Predicate<int> ((n) => n % 2 == 0);

            List<int> result = new List<int>();

            for (int i = bounds[0]; i <= bounds[1]; i++)
            {
                if (predicate(i))
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
