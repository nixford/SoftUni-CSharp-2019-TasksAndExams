using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            switch (command)
            {
                case "add":
                    GetAdd(a, b);
                    break;
                case "multiply":
                    GetMultiply(a, b);
                    break;
                case "subtract":
                    GetSubstract(a, b);
                    break;
                case "divide":
                    GetDivide(a, b);
                    break;
                default:
                    break;
            }

        }

        static void GetAdd(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        static void GetMultiply(int a, int b)
        {
            Console.WriteLine(a * b);
        }

        static void GetSubstract(int a, int b)
        {
            Console.WriteLine(a - b);
        }

        static void GetDivide(int a, int b)
        {
            Console.WriteLine(a / b);
        }
    }
}
