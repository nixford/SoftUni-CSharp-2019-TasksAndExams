using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            GetMultipleOfEvenAndOdds(number);
            Console.WriteLine(GetMultipleOfEvenAndOdds(number));
        }

        static int GetSumOfEvenDigits(int number)
        {
            int sumEven = 0;
            int lastDigit = 0;
            while (number != 0)
            {
                lastDigit = Math.Abs(number % 10);
                if (lastDigit % 2 == 0)
                {
                    sumEven = sumEven + lastDigit;
                }
                number = number / 10;
            }
            return sumEven;
        }

        static int GetSumOfOddDigits(int number)
        {
            int sumOdd = 0;
            int lastDigit = 0;
            while (number != 0)
            {
                lastDigit = Math.Abs(number % 10);
                if (lastDigit % 2 != 0)
                {
                    sumOdd = sumOdd + lastDigit;
                }
                number = number / 10;
            }
            return sumOdd;
        }

        static int GetMultipleOfEvenAndOdds(int number)
        {
            int total = GetSumOfEvenDigits(number) * GetSumOfOddDigits(number);
            return total;
        }
    }
}
