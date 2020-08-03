using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string topIntegers = " ";
            

            for (int i = 0; i < array.Length; i++)
            {
                int currentNumber = 0;
                for (int j = i + 1; j < array.Length; j++)
                {                   
                    if (array[i] > array[j])
                    {
                        currentNumber = currentNumber + 1;
                    }
                    else
                    {
                        break;
                    }
                }
                if (currentNumber == array.Length - i - 1)
                {
                    topIntegers = topIntegers + array[i] + " ";
                }               
            }
            Console.WriteLine(topIntegers);
        }
    }
}
