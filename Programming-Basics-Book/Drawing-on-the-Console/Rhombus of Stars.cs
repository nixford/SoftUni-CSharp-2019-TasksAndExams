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

            for (int row = 1; row <= n; row++)
            {
                for (int col = 1; col <= n - row; col++)
                {
                    Console.Write(" ");
                }
                Console.Write("*");
                for (int j = 1; j <= row - 1; j++)
                {
                    Console.Write(" *");
                }
                Console.WriteLine();
            }
            for (int row = 2; row <= n; row++)
            {
                for (int col = 1; col <= row - 1; col++)
                {
                    Console.Write(" ");
                }
                Console.Write("*");
                for (int j = 1; j <= n - row; j++)
                {
                    Console.Write(" *");
                }
                Console.WriteLine();
            }
        }
    }
}