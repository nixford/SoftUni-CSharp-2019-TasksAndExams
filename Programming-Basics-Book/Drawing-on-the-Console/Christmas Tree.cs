using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square_Frame
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine("{0}{1}{2}{1}{0}", new string(' ', n), " ", "|");

            for (int row = 1; row <= n; row++)
            {
                for (int col = 1; col <= n - row; col++)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= row; k++)
                {
                    Console.Write("*");
                }
                Console.Write(" ");
                Console.Write("|");
                Console.Write(" ");
                for (int m = 1; m <= row; m++)
                {
                    Console.Write("*");
                }
                for (int L = 1; L <= n - row; L++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
