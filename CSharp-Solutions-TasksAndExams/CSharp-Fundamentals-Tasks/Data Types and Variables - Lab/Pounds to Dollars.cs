using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pounds_to_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal dollars = decimal.Parse(Console.ReadLine());
            decimal pounds = dollars * 1.31m;
            Console.WriteLine($"{pounds:f3}");
        }
    }
}
