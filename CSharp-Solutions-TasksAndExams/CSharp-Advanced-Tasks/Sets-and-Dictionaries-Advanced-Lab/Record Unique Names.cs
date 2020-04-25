using System;
using System.Collections.Generic;

namespace Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < number; i++)
            {
                string currName = Console.ReadLine();
                names.Add(currName);
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
