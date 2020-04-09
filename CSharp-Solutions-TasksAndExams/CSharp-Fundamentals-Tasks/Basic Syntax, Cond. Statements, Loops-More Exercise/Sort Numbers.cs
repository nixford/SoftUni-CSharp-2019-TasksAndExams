using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            int largest = Math.Max(Math.Max(num1, num2), num3);
            int smallest = Math.Min(Math.Min(num1, num2), num3);
            int middle = (num1 + num2 + num3) - (largest + smallest);
            Console.WriteLine(largest);
            Console.WriteLine(middle);
            Console.WriteLine(smallest);
        }
    }
}
