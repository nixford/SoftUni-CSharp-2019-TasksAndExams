using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experience_Gaining
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededExperience = double.Parse(Console.ReadLine());
            int countOfBattles = int.Parse(Console.ReadLine());
            double experienceEarnedPerBattle = 0;

            double totalExperience = 0;
            int battleCount = 0;

            for (int i = 1; i <= countOfBattles; i++)
            {
                battleCount++;
                if (i % 3 == 0)
                {
                    totalExperience = totalExperience + (double.Parse(Console.ReadLine()) * 1.15);                    
                }
                else if (i % 5 == 0)
                {
                    totalExperience = totalExperience + (double.Parse(Console.ReadLine()) * 0.90);
                }
                else
                {
                    totalExperience = totalExperience + double.Parse(Console.ReadLine());
                }

                if (totalExperience >= neededExperience)
                {
                    break;
                }
            }
            if (totalExperience >= neededExperience)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {battleCount} battles.");
            }
            else
            {
                double diff = neededExperience - totalExperience;
                Console.WriteLine($"Player was not able to collect the needed experience, {diff:f2} more needed.");
            }            
        }
    }
}
