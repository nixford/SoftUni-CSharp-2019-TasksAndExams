using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int devisible = 0;
            bool notDivisible = false;
            int maxDivisible = int.MinValue;

            for (int i = 1; i <= 10; i++)
            {
                if (i == 2)
                {
                    if (num % 2 == 0)
                    {
                        devisible = 2;
                    }
                }
                else if (i == 3)
                {
                    if (num % 3 == 0)
                    {
                        devisible = 3;
                    }
                }
                else if (i == 6)
                {
                    if (num % 6 == 0)
                    {
                        devisible = 6;
                    }
                }
                else if (i == 7)
                {
                    if (num % 7 == 0)
                    {
                        devisible = 7;
                    }
                }
                else if (i == 10)
                {
                    if (num % 10 == 0)
                    {
                        devisible = 10;
                    }
                }      

                if (devisible > maxDivisible)
                {
                    maxDivisible = devisible;
                }
            }
            if (num % 2 != 0 && num % 3 != 0 && num % 6 != 0 && num % 7 != 0 && num % 10 != 0)
            {
                Console.WriteLine("Not divisible"); 
            }
            else
            {
                Console.WriteLine($"The number is divisible by {maxDivisible}");
            }                                   
        }
    }
}
