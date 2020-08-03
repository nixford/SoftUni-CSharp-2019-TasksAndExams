using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            double result = GetPower(number, power);
            Console.WriteLine(result);
        }

        static double GetPower(double number, int power)
        {
            double result = Math.Pow(number, power);
            return result;
        }
    }
}
