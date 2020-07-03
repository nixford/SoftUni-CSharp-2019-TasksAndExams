using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stop
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int dots = n + 1;
            int underscopes = 2 * n + 1;

            // FIRST ROW
            Console.WriteLine("{0}{1}{0}", new string('.', dots), new string('_', underscopes));

            // TOP MIDDLE
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}//{1}\\\\{0}", new string('.', dots - 1), new string('_', underscopes - 2));
                underscopes += 2;
                dots -= 1;
            }

            // MIDDLE ROW 
            Console.WriteLine("//{0}STOP!{0}\\\\", new string('_', (underscopes - 6) / 2));

            // BOTTOM ROWS
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}\\\\{1}//{0}", new string('.', i), new string('_', underscopes - 2));

                underscopes -= 2;
            }
        }
    }
}
