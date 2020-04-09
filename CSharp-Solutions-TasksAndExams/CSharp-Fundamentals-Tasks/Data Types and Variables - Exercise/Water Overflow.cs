using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int timesOfIncomingWater = int.Parse(Console.ReadLine());
            int totalLitters = 0;

            for (int i = 0; i < timesOfIncomingWater; i++)
            {
                int currentLiters = int.Parse(Console.ReadLine());                
                if (totalLitters + currentLiters > 255)
                {
                    Console.WriteLine("Insufficient capacity!");                    
                }
                else
                {
                    totalLitters = totalLitters + currentLiters;
                    continue;
                }
            }
            Console.WriteLine(totalLitters);
        }
    }
}
