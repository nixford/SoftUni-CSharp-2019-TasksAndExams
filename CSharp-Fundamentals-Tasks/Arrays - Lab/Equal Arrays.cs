using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] line1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int [] line2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();                                              
            
            int sumOfTheFirst = 0;
            bool isIdentical = true;

            for (int i = 0; i < line1.Length; i++)
            {
                if (line1[i] == line2[i])
                {
                    sumOfTheFirst = sumOfTheFirst + line1[i];

                }
                else
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    isIdentical = false;
                    break;
                }
            }
            if (isIdentical == true)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sumOfTheFirst}");
            }            
        }
    }
}
