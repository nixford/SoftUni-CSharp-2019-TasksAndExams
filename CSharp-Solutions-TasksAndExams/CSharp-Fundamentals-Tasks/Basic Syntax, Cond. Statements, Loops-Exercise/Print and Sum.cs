using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int numStart = int.Parse(Console.ReadLine());
            int numEnd = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int currentNumber = numStart; currentNumber <= numEnd; currentNumber++)
            {
                sum = sum + currentNumber;
                Console.Write(currentNumber + " ");
                
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
