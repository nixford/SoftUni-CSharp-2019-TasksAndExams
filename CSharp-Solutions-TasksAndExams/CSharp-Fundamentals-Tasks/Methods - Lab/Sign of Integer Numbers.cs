using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sign_of_Integer_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            SignofIntegerNumbers(numbers);
        }

        static void SignofIntegerNumbers(int numbers)
        {
            if (numbers > 0)
            {
                Console.WriteLine($"The number {numbers} is positive.");
            }
            else if (numbers < 0)
            {
                Console.WriteLine($"The number {numbers} is negative.");
            }
            else
            {
                Console.WriteLine($"The number {numbers} is zero.");
            }
        }
    }
}
