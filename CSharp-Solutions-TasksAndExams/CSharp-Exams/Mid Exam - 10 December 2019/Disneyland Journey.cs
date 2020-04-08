using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disneyland_Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double journeyCost = double.Parse(Console.ReadLine());
            int monthsNumberForSaving = int.Parse(Console.ReadLine());
            double totalSaved = 0;

            for (int i = 1; i <= monthsNumberForSaving; i++)
            {                
                if (i % 2 != 0 && i != 1)
                {
                    totalSaved = totalSaved - (totalSaved * 0.16);
                }               

                if (i % 4 == 0)
                {
                    totalSaved = totalSaved + (totalSaved * 0.25);
                }
                totalSaved = totalSaved + (journeyCost * 0.25);
            }

            if (totalSaved >= journeyCost)
            {
                double diff = totalSaved - journeyCost;
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {diff:f2}lv. for souvenirs.");
            }
            else
            {
                double diff = journeyCost - totalSaved;
                Console.WriteLine($"Sorry. You need {diff:f2}lv. more.");
            }
        }
    }
}
