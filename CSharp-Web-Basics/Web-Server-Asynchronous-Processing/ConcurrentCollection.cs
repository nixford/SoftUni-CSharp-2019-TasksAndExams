using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;

namespace ConcurrentCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new ConcurrentQueue<int>(Enumerable.Range(0, 10000).ToList());

            for (int i = 0; i < 4; i++) // the loop create four threads
            {
                new Thread(() =>
                {
                    while (numbers.Count > 0)
                        numbers.TryDequeue(out _); // TryDequeue removes the number, whithout (_) saving the result 
                }).Start();
            }
        }
    }
}
