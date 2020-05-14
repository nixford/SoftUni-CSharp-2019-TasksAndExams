using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amountMoney = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double pricePerLightsaber = double.Parse(Console.ReadLine());
            double pricePerRobe = double.Parse(Console.ReadLine());
            double pricePerBelt = double.Parse(Console.ReadLine());

            double totalPriceForLightsabbers = pricePerLightsaber * Math.Ceiling(studentsCount * 1.1);
            double totalPriceForRobes = pricePerRobe * studentsCount;
            double freeBelts = studentsCount / 6;
            double totalPriceForBelts = pricePerBelt * (studentsCount - freeBelts);

            double totalNeeded = totalPriceForLightsabbers + totalPriceForRobes + totalPriceForBelts;

            if (amountMoney >= totalNeeded)
            {
                Console.WriteLine($"The money is enough - it would cost {totalNeeded:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {totalNeeded - amountMoney:f2}lv more.");
            }
        }
    }
}
