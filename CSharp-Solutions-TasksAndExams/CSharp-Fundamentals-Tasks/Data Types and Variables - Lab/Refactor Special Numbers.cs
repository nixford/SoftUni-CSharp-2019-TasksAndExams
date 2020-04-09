using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());            
            
            for (int i = 1; i <= num; i++)
            {
                int current = i;
                double sum = 0;
                bool isSpecial = false;
                while (current > 0)
                {
                    sum += current % 10;
                    current /= 10;
                }
                if ((sum == 5) || (sum == 7) || (sum == 11))
                {
                    isSpecial = true;
                } 
                Console.WriteLine("{0} -> {1}", i, isSpecial);               
            }
        }
    }
}
