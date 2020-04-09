using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tribonacci_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {            
            int number = Math.Abs(int.Parse(Console.ReadLine()));
            GetTribunachiSequence(number);
            Console.WriteLine(string.Join(" ", GetTribunachiSequence(number)));
        }

        static int[] GetTribunachiSequence(int number)
        {
            int[] arr = new int[number];
            if (number > 3)
            {                
                arr[0] = 1;
                arr[1] = 1;
                arr[2] = 2;
                int previous1 = arr[0];
                int previous2 = arr[1];
                int previous3 = arr[2];
                for (int i = 3; i < number; i++)
                {
                    arr[i] = previous1 + previous2 + previous3;
                    previous1 = previous2;
                    previous2 = previous3;
                    previous3 = arr[i];
                }
                return arr;
            }
            else if (number == 3)
            {
                arr[0] = 1;
                arr[1] = 1;
                arr[2] = 2;
                return arr;
            }
            else if (number == 2)
            {
                arr[0] = 1;
                arr[1] = 1;
                return arr;
            }
            else
            {
                arr[0] = 1;                
                return arr;
            }                 
        }
    }
}
