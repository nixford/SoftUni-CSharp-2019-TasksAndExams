using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floating_Equality
{
    class Program
    {
        static void Main(string[] args)
        {
            double numLeft = double.Parse(Console.ReadLine());
            double numRight = double.Parse(Console.ReadLine());
            double eps = 0.000001;

            
            if (Math.Abs(numLeft - numRight) >= eps)
            {
                Console.WriteLine("False");
            }
            else
            {
                Console.WriteLine("True");
            }       
        }
    }
}
