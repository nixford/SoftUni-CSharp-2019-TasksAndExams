using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace GenericBox
{
    class Startup
    {
        static void Main(string[] args)
        {           
            int n = int.Parse(Console.ReadLine());

            List<int> numbers = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                numbers.Add(number);
                
            }
            Box<int> box = new Box<int>(numbers);

            int[] indexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int indexOne = indexes[0];
            int indexTwo = indexes[1];

            box.Swap(numbers, indexOne, indexTwo);

            Console.WriteLine(box.ToString());            
        }
    }
}
