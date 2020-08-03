using System;
using System.Linq;

namespace Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();            

            Console.WriteLine(Sum(input));
        }
        public static int Sum(int[] arr, int index = 0)
        {
            if (index == arr.Length)
            {
                return 0;
            }
            return arr[index] + Sum(arr, index + 1);
        }
    }
}
