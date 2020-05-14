using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int fibonachiNum = int.Parse(Console.ReadLine());
            int[] array = new int[] { 1, 1 };
            int sum = 0;

            switch (fibonachiNum)
            {
                case 1:
                    Console.WriteLine("1");
                    return;
                case 2:
                    Console.WriteLine("1");
                    return;
            }

            for (int i = 2; i < fibonachiNum; i++)
            {
                sum = array[0] + array[1];
                int[] newArray = new int[] { array[1], sum };

                array = newArray;
            }
            Console.WriteLine(sum);
        }        
    }
}
