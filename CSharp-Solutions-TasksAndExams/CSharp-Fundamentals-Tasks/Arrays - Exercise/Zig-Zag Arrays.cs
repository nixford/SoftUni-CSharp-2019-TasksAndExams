using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //int n = int.Parse(Console.ReadLine());

            //int[] array1 = new int[n];
            //int[] array2 = new int[n];

            //for (int i = 0; i < n; i++)
            //{
            //    int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            //    int num1 = line[0];          
            //    int num2 = line[1];

            //    if (i % 2 == 0)
            //    {
            //        array1[i] = num1;
            //        array2[i] = num2;
            //    }
            //    else
            //    {
            //        array1[i] = num2;
            //        array2[i] = num1;
            //    }
            //}

            //for (int i = 0; i < n; i++)
            //{
            //    Console.Write(array1[i] + " ");                
            //}
            //Console.WriteLine();
            //for (int i = 0; i < n; i++)
            //{                
            //    Console.Write(array2[i] + " ");
            //}
            //Console.WriteLine();

            int n = int.Parse(Console.ReadLine());
            int[] array1 = new int[n];
            int[] array2 = new int[n];
            for (int i = 0; i < n; i++)
            {
                int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int num1 = line[0];
                int num2 = line[1];
                if (i % 2 == 0)
                {
                    array1[i] = num1;
                    array2[i] = num2;
                }
                else
                {
                    array1[i] = num2;
                    array2[i] = num1;
                }
            }
            Console.WriteLine(string.Join(" ", array1));
            Console.WriteLine(string.Join(" ", array2));
        }
    }
}
