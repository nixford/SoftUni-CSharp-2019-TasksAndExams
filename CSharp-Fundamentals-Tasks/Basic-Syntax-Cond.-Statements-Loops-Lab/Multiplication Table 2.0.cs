using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplication_Table_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());
            int count = multiplier;
            int product = 1;

            do
            {
                product = n * count;
                Console.WriteLine($"{n} X {count} = {product}");
                count++;
            } while (count <= 10);           
        }
    }
}
