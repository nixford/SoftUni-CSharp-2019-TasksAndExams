using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool isEven = false; 

            while (isEven == false)
            {
                if (n % 2 != 0)
                {
                    Console.WriteLine("Please write an even number.");                    
                }
                else
                {
                    Console.WriteLine($"The number is: {Math.Abs(n)}");
                    isEven = true;
                    break;
                }
                n = int.Parse(Console.ReadLine());
            }

        }
    }
}
