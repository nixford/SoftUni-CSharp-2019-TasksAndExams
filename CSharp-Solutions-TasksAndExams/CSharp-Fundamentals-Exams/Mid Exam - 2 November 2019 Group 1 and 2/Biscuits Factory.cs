using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biscuits_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            double bisquitNumberFromWorkerPerDay = double.Parse(Console.ReadLine());
            double workersNumber = double.Parse(Console.ReadLine());
            double otherCompanyBisquitsPerMonth = double.Parse(Console.ReadLine());

            double totalBisquits = 0;

            for (int i = 0; i < 30; i++)
            {
                if (i % 3 == 0)
                {
                    totalBisquits = totalBisquits + Math.Floor(bisquitNumberFromWorkerPerDay * 0.75 * workersNumber);
                }
                else
                {
                    totalBisquits = totalBisquits + bisquitNumberFromWorkerPerDay * workersNumber;
                }
            }
            Console.WriteLine($"You have produced {totalBisquits} biscuits for the past month.");
            
            if (totalBisquits > otherCompanyBisquitsPerMonth)
            {
                double diff = totalBisquits - otherCompanyBisquitsPerMonth;
                double percentage = diff / otherCompanyBisquitsPerMonth * 100;
                Console.WriteLine($"You produce {percentage:f2} percent more biscuits.");
            }
            else
            {
                double diff = otherCompanyBisquitsPerMonth - totalBisquits;
                double percentage = Math.Abs(diff / otherCompanyBisquitsPerMonth * 100);
                Console.WriteLine($"You produce {percentage:f2} percent less biscuits.");                
            }
        }
    }
}
