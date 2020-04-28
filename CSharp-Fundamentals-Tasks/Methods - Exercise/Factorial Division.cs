using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            decimal total = GetResult(firstNumber, secondNumber);
            Console.WriteLine($"{total:f2}");       
        }

        static decimal GetFactorialOfFirstNumber(int firstNumber)
        {
            decimal result = 1;            
            while (firstNumber != 0)
            {                
                result = result * firstNumber;
                firstNumber = firstNumber - 1;                                
            }
            return result;
        }

        static decimal GetFactorialOfSecondNumber(int secondNumber)
        {
            decimal result = 1;
            while (secondNumber != 0)
            {
                result = result * secondNumber;
                secondNumber = secondNumber - 1;
            }
            return result;
        }

        static decimal GetResult(int firstNumber, int secondNumber)
        {
            decimal totalResult = GetFactorialOfFirstNumber(firstNumber) / GetFactorialOfSecondNumber(secondNumber);
            return totalResult;
        }
    }
}
