using System;
using System.Linq;

namespace Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Comparator has three inputs - first two inputs may be from different types,
            // the third one is always from int type;

            Func<int, int, int> comparator =
                new Func<int, int, int>((a, b) => 
                {
                if (a % 2 == 0 && b % 2 != 0)
                {
                    return -1; // if you wont the first object to stay first
                }
                else if (a % 2 != 0 && b % 2 == 0)
                {
                    return 1;// if you wont the second object to stay first
                    }
                else
                {
                    return a.CompareTo(b); // Usually it stays only as return;
                }
            });

            Comparison<int> comparison = new Comparison<int>(comparator);

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Array.Sort(numbers, comparison);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
