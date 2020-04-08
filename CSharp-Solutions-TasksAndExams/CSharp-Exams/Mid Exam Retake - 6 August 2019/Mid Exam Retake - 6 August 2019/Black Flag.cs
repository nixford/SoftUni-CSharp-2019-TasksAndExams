using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Black_Flag
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOfPlunder = int.Parse(Console.ReadLine());
            int plunderPerDays = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());

            double totalPlunder = 0;

            for (int i = 1; i <= daysOfPlunder; i++)
            {
                totalPlunder = totalPlunder + plunderPerDays;
                if (i % 3 == 0)
                {
                    totalPlunder = totalPlunder + (plunderPerDays * 0.50);
                }

                if (i % 5 == 0)
                {                    
                    totalPlunder = totalPlunder - (totalPlunder * 0.30);
                }                        
            }

            if (totalPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");
            }
            else
            {
                double percentege = (totalPlunder / expectedPlunder) * 100;
                Console.WriteLine($"Collected only {percentege:f2}% of the plunder.");
            }
        }
    }
}
