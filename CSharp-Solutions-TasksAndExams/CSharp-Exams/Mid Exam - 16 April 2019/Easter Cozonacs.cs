using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easter_Cozonacs
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double priceFor1KgFloor = double.Parse(Console.ReadLine());

            double priceFor1PackEggs = priceFor1KgFloor * 0.75;
            double priceFor1lMilk = priceFor1KgFloor * 1.25;
            double priceForMilkFor1Cozonac = priceFor1lMilk / 4;
            double totalPricePerCozonac = priceFor1KgFloor + priceFor1PackEggs + priceForMilkFor1Cozonac;

            double totalCozonacsCount = 0;
            double totalColloredEgs = 0;

            while (budget > 0)
            {       
                if (budget - totalPricePerCozonac > 0)
                {
                    budget = budget - totalPricePerCozonac;
                    totalCozonacsCount++;
                    totalColloredEgs = totalColloredEgs + 3;
                    if (totalCozonacsCount % 3 == 0)
                    {
                        totalColloredEgs = totalColloredEgs - (totalCozonacsCount - 2);
                    }
                }
                else
                {
                    break;
                }                
            }
            Console.WriteLine($"You made {totalCozonacsCount} cozonacs! Now you have {totalColloredEgs} eggs and {budget:f2}BGN left.");
        }
    }
}
