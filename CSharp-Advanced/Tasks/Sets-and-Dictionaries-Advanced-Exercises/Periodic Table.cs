using System;
using System.Collections.Generic;
using System.Linq;

namespace Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            HashSet<string> elements = new HashSet<string>();

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                for (int j = 0; j < input.Length; j++)
                {
                    elements.Add(input[j]);
                }
                
            }
            foreach (var element in elements.OrderBy(a => a))
            {
                Console.Write(element + " ");
            }           
        }
    }
}
