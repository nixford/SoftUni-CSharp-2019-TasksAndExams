using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (n % 2 != 0)
            {
                // TOP ROW
                Console.WriteLine("{0}{1}{0}", new string('.', (n - 1) / 2), new string('#', n));

                // MIDDLE TOP
                for (int i = 2; i <= n - 1; i++)
                {
                    Console.Write("{0}", new string('.', (n - 1) / 2));
                    Console.Write("#");
                    Console.Write("{0}", new string('.', n - 2));
                    Console.Write("#");
                    Console.Write("{0}", new string('.', (n - 1) / 2));
                    Console.WriteLine();
                }

                // MIDDLE ROW
                Console.WriteLine("{0}{1}{0}", new string('#', (n + 1) / 2), new string('.', n - 2));

                // MIDDLE BOTTOM
                for (int col = 1; col <= n - 2; col++)
                {
                    Console.Write("{0}", new string('.', col));
                    Console.Write("#");
                    Console.Write("{0}", new string('.', Math.Abs((n * 2 - 1) - (2 + 2 * col))));
                    Console.Write("#");
                    Console.Write("{0}", new string('.', col));
                    Console.WriteLine();
                }

                // BOTTOM ROW
                Console.WriteLine("{0}#{0}", new string('.', (n - 1)));
            }
        }
    }
}
