using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            GetTopNumber(n);
        }

        static void GetTopNumber(int n)
        {
            
            int currNumber = 0;
            double sum = 0;

            for (int i = 1; i <= n; i++)
            {
                currNumber = i;
                sum = 0;
                bool isDivisibleByEight = false;
                bool haveOddDigit = false;

                while (currNumber > 0)
                {                    
                    int lastDigit = currNumber % 10;
                    sum = sum + lastDigit;
                    currNumber = currNumber / 10;
                }
                if (sum % 8 == 0)
                {
                    isDivisibleByEight = true;
                }
                
                currNumber = i;                
                while (currNumber > 0)
                {                    
                    int lastDigit = currNumber % 10;
                    if (!(lastDigit % 2 == 0))
                    {
                        haveOddDigit = true;
                    }                    
                    currNumber = currNumber / 10;
                }

                if (isDivisibleByEight && haveOddDigit)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
