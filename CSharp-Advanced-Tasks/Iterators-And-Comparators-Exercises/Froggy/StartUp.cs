using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(new string[] { ", " }, 
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Lake lake = new Lake(input);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
