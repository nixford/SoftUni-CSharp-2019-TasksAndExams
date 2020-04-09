using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            SubstractInteger(num1, num2, num3);
            Console.WriteLine(SubstractInteger(num1, num2, num3));
        }

        static int SumInteger(int num1, int num2)
        {
            int result = num1 + num2;
            return result;
        }

        static int SubstractInteger(int num1, int num2, int num3)
        {
            int sum = SumInteger(num1, num2);
            int total = sum - num3;
            return total;
        }
    }
}
