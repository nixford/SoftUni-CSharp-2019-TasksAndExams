using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string[] element = line.Split(' ');
            int [] digits = element.Select(int.Parse).ToArray();

            int currentDigit = 0;
            int sumEven = 0;
            int sumOdd = 0;

            for (int i = 0; i < digits.Length; i++)
            {
                currentDigit = digits[i];
                if (currentDigit % 2 == 0)
                {
                    sumEven = sumEven + currentDigit;
                }
                else
                {
                    sumOdd = sumOdd + currentDigit;
                }
            }
            Console.WriteLine(sumEven - sumOdd);
        }
    }
}
        