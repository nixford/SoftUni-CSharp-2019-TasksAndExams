using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            Thread thread = new Thread(MyThreadMainMethod);
            thread.Start();

            while (true)
            {
                var line = Console.ReadLine();
                Console.WriteLine(line.ToUpper());
            }                     
        }

        private static void MyThreadMainMethod()
        {
            ulong toNumber = 1000000000;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            int count = 0;

            count = GetEvenNumbersCount(0, toNumber / 2, count);
            var task1 = Task.Run(() => GetEvenNumbersCount(toNumber / 2 + 1, toNumber, count));
           
            Console.WriteLine(count);
            Console.WriteLine($"Total time: {sw.Elapsed}");
        }

        private static int GetEvenNumbersCount(ulong fromNumber, ulong toNumber, int count)
        {
            for (ulong i = fromNumber; i < toNumber; i++)
            {
                if (i % 2 == 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
