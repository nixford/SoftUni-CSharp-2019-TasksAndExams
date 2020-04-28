using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int count = 1;
            int product = 1;

            while (count <= 10)
            {
                product = n * count;
                Console.WriteLine($"{n} X {count} = {product}");
                count++;
            }
        }
    }
}
