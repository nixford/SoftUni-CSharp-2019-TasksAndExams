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
            int n = int.Parse(Console.ReadLine());

            // FIRST ROW - EVEN AND ODD
            if (n % 2 == 0)
            {
                Console.Write("{0}{1}{0}", new string('-', (n / 2) - 1), "**");
            }
            else
            {
                Console.Write("{0}{1}{0}", new string('-', (n - 1) / 2), "*");
            }
            Console.WriteLine();

            // ROOF - EVEN
            if (n % 2 == 0)
            {
                for (int row = 2; row <= n / 2; row++)
                {
                    for (int col = 1; col <= n / 2 - row; col++)
                    {
                        Console.Write("-");
                    }
                    for (int col = 1; col <= row * 2; col++)
                    {
                        Console.Write("*");
                    }
                    for (int col = 1; col <= n / 2 - row; col++)
                    {
                        Console.Write("-");
                    }
                    Console.WriteLine();
                }

                // FOUNDATION = EVEN
                for (int row = n / 2; row <= n - 1; row++)
                {
                    Console.Write("|");
                    for (int col = 1; col <= n - 2; col++)
                    {
                        Console.Write("*");
                    }
                    Console.Write("|");
                    Console.WriteLine();
                }
            }
            else
            {
                // ROOF - ODD
                for (int row = 2; row <= (int)Math.Ceiling(n / 2f); row++)
                {
                    for (int col = (int)Math.Ceiling(n / 2f); col <= n - row; col++)
                    {
                        Console.Write("-");
                    }
                    for (int col = 1; col <= row * 2 - 1; col++)
                    {
                        Console.Write("*");
                    }
                    for (int col = (int)Math.Ceiling(n / 2f); col <= n - row; col++)
                    {
                        Console.Write("-");
                    }
                    Console.WriteLine();
                }

                // FOUNDATION = ODD
                for (int row = n / 2; row <= n - 2; row++)
                {
                    Console.Write("|");
                    for (int col = 1; col <= n - 2; col++)
                    {
                        Console.Write("*");
                    }
                    Console.Write("|");
                    Console.WriteLine();
                }
            }
        }
    }
}