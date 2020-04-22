using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamant
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (n == 1)
            {
                Console.WriteLine("*");
            }
            else if (n == 2)
            {
                Console.WriteLine("**");
            }

            else if (n % 2 == 0)
            {
                // FIRST ROW
                Console.WriteLine("{0}**{0}", new string('-', (n / 2) - 1));

                // TOP MIDDLE ROWS
                for (int col = 1; col <= n / 2 - 2; col++)
                {
                    Console.Write(new string('-', (n / 2) - col - 1));
                    Console.Write("*");
                    Console.Write(new string('-', col * 2));
                    Console.Write("*");
                    Console.Write(new string('-', (n / 2) - col - 1));
                    Console.WriteLine();
                }

                // MIDDLE ROW
                Console.WriteLine("*{0}*", new string('-', n - 2));

                // BOTTOM MIDDLE ROWS
                for (int col = (n / 2) - 2; col >= 1; col--)
                {
                    Console.Write(new string('-', (n / 2) - col - 1));
                    Console.Write("*");
                    Console.Write(new string('-', col * 2));
                    Console.Write("*");
                    Console.Write(new string('-', (n / 2) - col - 1));
                    Console.WriteLine();
                }

                // LAST ROW
                Console.WriteLine("{0}**{0}", new string('-', (n / 2) - 1));
            }

            else if (n % 2 != 0)
            {
                // FIRST ROW
                Console.WriteLine("{0}*{0}", new string('-', (n - 1) / 2));

                // TOP MIDDLE ROWS
                for (int col = 1; col <= n / 2 - 1; col++)
                {
                    for (int row = 1; row <= n / 2 - col; row++)
                    {
                        Console.Write("-");
                    }
                    for (int row2 = 1; row2 <= 1; row2++)
                    {
                        Console.Write("*");
                    }
                    for (int row3 = 1; row3 <= col * 2 - 1; row3++)
                    {
                        Console.Write("-");
                    }
                    for (int row2 = 1; row2 <= 1; row2++)
                    {
                        Console.Write("*");
                    }
                    for (int row = 1; row <= n / 2 - col; row++)
                    {
                        Console.Write("-");
                    }
                    Console.WriteLine();
                }

                // MIDDLE ROW
                Console.WriteLine("*{0}*", new string('-', n - 2));

                // BOTTOM MIDDLE ROWS
                for (int col = n / 2 - 1; col >= 1; col--)
                {
                    for (int row = 1; row <= n / 2 - col; row++)
                    {
                        Console.Write("-");
                    }
                    for (int row2 = 1; row2 <= 1; row2++)
                    {
                        Console.Write("*");
                    }
                    for (int row3 = 1; row3 <= col * 2 - 1; row3++)
                    {
                        Console.Write("-");
                    }
                    for (int row2 = 1; row2 <= 1; row2++)
                    {
                        Console.Write("*");
                    }
                    for (int row = 1; row <= n / 2 - col; row++)
                    {
                        Console.Write("-");
                    }
                    Console.WriteLine();
                }

                // LAST ROW
                Console.WriteLine("{0}*{0}", new string('-', (n - 1) / 2));
            }
        }
    }
}