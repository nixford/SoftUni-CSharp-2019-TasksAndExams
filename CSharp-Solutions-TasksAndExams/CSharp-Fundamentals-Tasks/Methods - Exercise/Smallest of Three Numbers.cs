using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            GetMin(num1, num2, num3);
            Console.WriteLine(GetMin(num1, num2, num3));
        }

        //static int GetMin(params int[] inputs)
        //{
        //    return inputs.Min();
        //}

        //static int GetMin(int num1, int num2, int num3)
        //{            
        //    return Math.Min(num1, Math.Min(num2, num3));
        //}

        static int GetMin(int num1, int num2, int num3)
        {
            int[] numbers = new[] { num1, num2, num3 };
            int min = numbers.Min();
            return min;            
        }       
    }
}

