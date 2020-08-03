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

            List<string> names = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                names.Add(name);
                
            }
            Box<string> box = new Box<string>(names);

            int[] indexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int indexOne = indexes[0];
            int indexTwo = indexes[1];

            box.Swap(names, indexOne, indexTwo);

            Console.WriteLine(box.ToString());
            
        }
    }
}
