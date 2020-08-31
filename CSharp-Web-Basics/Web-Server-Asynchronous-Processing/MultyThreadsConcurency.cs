using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MultyThreads_Concurency
{
    class Program
    {
        static void Main(string[] args)
        {
            
            TestThreadsMethod();
            //return;

            object lockObj = new object();

            decimal money = 0;

            var thread1 = new Thread(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    lock(lockObj)
                    {
                        money++;
                    }                    
                }
            });
            thread1.Start();

            var thread2 = new Thread(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    lock (lockObj)
                    {
                        money++;
                    }
                }
            });
            thread2.Start();

            var thread3 = new Thread(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    lock (lockObj)
                    {
                        money++;
                    }
                }
            });
            thread3.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join(); // in order to be waited for the complition for both threads.

            Console.WriteLine(money);
        }

        private static void TestThreadsMethod()
        {
            object lockObj = new object();
            decimal money = 0; // common vatiable(shared memory)

            ThreadStart incrementMyMoney = () =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    lock (lockObj)
                    {
                        money++;
                    }
                }
            };

            var thread1 = new Thread(incrementMyMoney);
            thread1.Start();
            var thread2 = new Thread(incrementMyMoney);
            thread2.Start();
            var thread3 = new Thread(incrementMyMoney);
            thread3.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();

            Console.WriteLine(money);
        }


        private static void DeadLock() // Example
        {
            var lockObj1 = new object();
            var lockObj2 = new object();

            var thread1 = new Thread(() => 
            { 
                lock(lockObj1)
                {
                    Thread.Sleep(1000);
                    lock(lockObj2)
                    {

                    }
                }
            });
            var thread2 = new Thread(() =>
            {
                lock (lockObj2)
                {
                    Thread.Sleep(1000);
                    lock (lockObj1)
                    {

                    }
                }
            });

            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();            
        }
    }
}
