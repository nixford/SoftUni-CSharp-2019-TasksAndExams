using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var colSize = n / 2;
            var midSize = 2 * n - 2 * colSize - 4;

            // ROOF
            Console.WriteLine("/{0}\\{1}/{0}\\", new string('^', colSize), new string('_', midSize));

            // BODY
            for (int row = 1; row <= n - 3; row++)
            {
                Console.WriteLine("|{0}|", new string(' ', 2 * n - 2));
            }

            // BOTOM
            Console.WriteLine("|{0}{1}{0}|", new string(' ', colSize + 1), new string('_', midSize));
            Console.WriteLine("\\{0}/{1}\\{0}/", new string('_', colSize), new string(' ', midSize));
        }
    }
}