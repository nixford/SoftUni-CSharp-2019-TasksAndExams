using System;
using System.Collections.Generic;

namespace GenericBox
{
    class Startup
    {
        static void Main(string[] args)
        {           
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int value = int.Parse(Console.ReadLine());

                Box<int> box = new Box<int>(value);

                Console.WriteLine(box.ToString());
            }            
        }
    }
}
