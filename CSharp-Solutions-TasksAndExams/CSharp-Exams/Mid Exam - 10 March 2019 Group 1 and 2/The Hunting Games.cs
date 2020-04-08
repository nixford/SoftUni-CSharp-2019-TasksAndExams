using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Hunting_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysNumber = int.Parse(Console.ReadLine());
            int playersCount = int.Parse(Console.ReadLine());
            double groupEnergy = double.Parse(Console.ReadLine());
            double waterPerDayForPerson = double.Parse(Console.ReadLine());
            double foodPerDayForOnePerson = double.Parse(Console.ReadLine());

            double waterSupplies = waterPerDayForPerson * playersCount * daysNumber;
            double foodSupplies = foodPerDayForOnePerson * playersCount * daysNumber;

            double energyLossPerDay = 0;

            for (int i = 1; i <= daysNumber; i++)
            {
                energyLossPerDay = double.Parse(Console.ReadLine());
                groupEnergy = groupEnergy - energyLossPerDay;
                if (groupEnergy <= 0)
                {
                    break;
                }

                if (i % 2 == 0)
                {
                    groupEnergy = groupEnergy * 1.05;
                    waterSupplies = waterSupplies * 0.70;
                }

                if (i % 3 == 0)
                {
                    groupEnergy = groupEnergy * 1.10;
                    foodSupplies = foodSupplies - (foodSupplies / playersCount);
                }
               
            }
            if (groupEnergy <= 0)
            {
                Console.WriteLine($"You will run out of energy. You will be left with {foodSupplies:f2} food and {waterSupplies:f2} water.");
            }
            else
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:f2} energy!");
            }            
        }
    }
}
