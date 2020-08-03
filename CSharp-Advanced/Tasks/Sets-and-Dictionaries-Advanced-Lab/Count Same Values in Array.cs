using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();

            Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int i = 0; i < input.Length; i++)
            {
                string key = input[i];
                if (!dict.ContainsKey(key))
                {
                    dict.Add(key, 1);
                }
                else
                {
                    dict[key]++;
                }
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
