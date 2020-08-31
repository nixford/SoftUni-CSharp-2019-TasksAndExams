using System;
using System.Linq;

namespace ParallelLINQTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 2, 3, 4, 5 }; 
            
            var evenNumsParallel = from num in nums.AsParallel()
                                     where num % 2 == 0
                                     select num; // not allowed in SQL still
        }
    }
}
