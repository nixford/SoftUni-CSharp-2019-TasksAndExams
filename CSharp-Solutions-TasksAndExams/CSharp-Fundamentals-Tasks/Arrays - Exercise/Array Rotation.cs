using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());
            int[] firstElementToEnd = new int[array.Length];

            for (int currentRotation = 0; currentRotation < rotations; currentRotation++)
            {
                firstElementToEnd = new int[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    if (i == 0)
                    {
                        firstElementToEnd[i] = array[1];
                    }
                    else if (i > 0 && i < array.Length - 1)
                    {
                        firstElementToEnd[i] = array[i + 1];
                    }
                    else
                    {
                        firstElementToEnd[i] = array[0];
                    }
                }
                array = firstElementToEnd;
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(firstElementToEnd[i] + " ");
            }
            Console.WriteLine();

            //int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //int rotations = int.Parse(Console.ReadLine());
            //int[] revercedNumbers = new int[numbers.Length];

            //for (int i = 0; i < rotations; i++)
            //{
            //    revercedNumbers = new int[numbers.Length];
            //    for (int j = 0; j < numbers.Length; j++)
            //    {                    
            //        if (j >= 0 && j < numbers.Length - 1)
            //        {
            //            revercedNumbers[j] = numbers[j + 1];
            //        }
            //        else if (j == numbers.Length - 1)
            //        {
            //            revercedNumbers[numbers.Length - 1] = numbers[0];
            //        }
            //    }
            //    numbers = revercedNumbers;
            //}
            //Console.WriteLine(string.Join(" ", revercedNumbers));
        }
    }
}
