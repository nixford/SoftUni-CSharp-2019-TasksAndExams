using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strong_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int currentFactorial = 1;
            int sumFactorial = 0;
            int digit = 0;
            int intput = num;

            do
            {
                digit = num % 10; // намира последната цфра
                num = num / 10;  // премахва последната цифра

                currentFactorial = 1;
                for (int i = digit; i >= 1; i--)
                {
                    currentFactorial = currentFactorial * i;
                }
                sumFactorial = sumFactorial + currentFactorial;               

            } while (num > 0);

            if (sumFactorial == intput)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
