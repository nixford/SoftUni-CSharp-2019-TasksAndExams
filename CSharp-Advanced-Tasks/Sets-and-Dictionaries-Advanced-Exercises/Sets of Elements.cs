using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int firstSet = sets[0];
            int secondSet = sets[1];
            HashSet<string> dataBaseFirst = new HashSet<string>();
            HashSet<string> dataBaseSecond = new HashSet<string>();

            for (int i = 0; i < firstSet; i++)
            {
                string currNumber = Console.ReadLine();
                dataBaseFirst.Add(currNumber);
            }
            for (int i = 0; i < secondSet; i++)
            {
                string currNumber = Console.ReadLine();
                dataBaseSecond.Add(currNumber);
            }

            foreach (var item in dataBaseFirst)
            {
                if (dataBaseSecond.Contains(item))
                {
                    Console.Write(item + " ");
                }
            }
        }
    }
}
