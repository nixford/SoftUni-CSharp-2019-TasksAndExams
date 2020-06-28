using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int width = 2 * n - 1;
            int height = 2 * (n - 2) + 1;

            int leftAndRight = n - 1;
            int halfRowSize = n - 2;

            for (int i = 1; i <= halfRowSize; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine("{0}\\ /{0}", new string('*', halfRowSize));
                }
                else
                {
                    Console.WriteLine("{0}\\ /{0}", new string('-', n - 2));
                }
            }
            Console.WriteLine("{0}@{0}", new string(' ', n - 1));

            for (int i = 1; i <= halfRowSize; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine("{0}/ \\{0}", new string('*', halfRowSize));
                }
                else
                {
                    Console.WriteLine("{0}/ \\{0}", new string('-', n - 2));
                }
            }
        }
    }
}
