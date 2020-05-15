﻿using System;
using System.Linq;

namespace Binary_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int key = int.Parse(Console.ReadLine());

            if (input == String.Empty)
            {
                return;
            }

            int[] arr = input
                .Split()
                .Select(int.Parse)
                .ToArray();

            int index = BinarySearch.IndexOf(arr, key);
            Console.WriteLine(index);
        }

        public class BinarySearch
        {
            public static int IndexOf(int[] arr, int key)
            {
                int lo = 0;
                int hi = arr.Length - 1;

                while (lo <= hi)
                {
                    int mid = lo + (hi - lo) / 2;

                    if (key < arr[mid])
                    {
                        hi = mid - 1;
                    }
                    else if (key > arr[mid])
                    {
                        lo = mid + 1;
                    }
                    else
                    {
                        return mid;
                    }
                }

                return -1;
            }
        }
    }
}
