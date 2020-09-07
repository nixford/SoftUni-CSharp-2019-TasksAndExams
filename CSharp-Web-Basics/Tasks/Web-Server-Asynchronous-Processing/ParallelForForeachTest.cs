using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ParallelForForeachTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int toNumber = 1000000; // 1 000 000           

            Stopwatch sw = new Stopwatch();
            sw.Start();

            int count = 0;

            // toNumber: 1 000 000 
            // count: 78500
            // Total time: 00:00:03.4654425

            //count = GetPrimeNumbersCount(0, toNumber);

            // toNumber: 78500
            // count: 500000
            // Total time: 00:00:01.6697192

            //count = GetPrimeNumbersParallelFor(0, toNumber);

            Console.WriteLine(count);
            Console.WriteLine($"Total time: {sw.Elapsed}");
        }

        private static int GetPrimeNumbersCount(int fromNumber, int toNumber)
        {
            int count = 0;
           
            for (int i = fromNumber; i < toNumber; i++)
            {
                bool isPrime = true;
                for (int div = 2; div <= Math.Sqrt(i); div++)
                {
                    if (i % div == 0)
                    {
                        isPrime = false;
                    }
                }

                if (isPrime)
                { 
                    count++;                   
                }
            }

            return count;
        }

        private static int GetPrimeNumbersParallelFor(int fromNumber, int toNumber)             
        {
            int count = 0;
            object lockObj = new object();

            Parallel.For(fromNumber, toNumber, (i) => // separates the loop in parts and execute the respective parts separately parallel
            {
                bool isPrime = true;
                for (int div = 2; div <= Math.Sqrt(i); div++)
                {
                    if (i % div == 0)
                    {
                        isPrime = false;
                    }
                }

                if (isPrime)
                {
                    lock(lockObj)
                    {
                        count++;
                    }
                }
            });

            return count;
        }
    }
}
