using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal firstNumber = decimal.Parse(Console.ReadLine());
            string operetor = Console.ReadLine();
            decimal secondNumber = decimal.Parse(Console.ReadLine());
            decimal result = GetResult(firstNumber, operetor, secondNumber);
            Console.WriteLine(result);
        }

        static decimal GetResult(decimal firstNumber, string operetor, decimal secondNumber)
        {
            decimal result = 0;
            switch (operetor)
            {
                case "/":
                    result = firstNumber / secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
