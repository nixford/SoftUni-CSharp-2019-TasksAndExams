using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsNumber = int.Parse(Console.ReadLine());
            int[] initialArray = new int[] { 1, 1 };

            Console.WriteLine(1);
            if (rowsNumber == 1) // Drowning first row
            {                
                return;
            }

            Console.WriteLine(string.Join(" ", initialArray));  // Drowning second row
            if (rowsNumber == 2)
            {                
                return;
            }
            else // Drowning the remaining part
            {
                for (int row = 0; row < initialArray.Length + 1; row++)
                {
                    int[] array = new int[initialArray.Length + 1];
                    array[0] = 1;
                    array[array.Length - 1] = 1;

                    for (int cols = 1; cols < array.Length - 1; cols++)
                    {
                        array[cols] = initialArray[cols - 1] + initialArray[cols];
                    }
                    Console.WriteLine(string.Join(" ", array));

                    initialArray = array;

                    if (initialArray.Length == rowsNumber)
                    {
                        break;
                    }
                }
            }
        }
    }
}
