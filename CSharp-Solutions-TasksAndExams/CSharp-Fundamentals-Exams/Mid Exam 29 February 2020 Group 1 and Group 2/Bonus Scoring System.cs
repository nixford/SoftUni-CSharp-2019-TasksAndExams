using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonus_Scoring_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            int initialBonus = int.Parse(Console.ReadLine());

            double totalBonus = 0;
            double roundedTotalBonus = 0;
            double maxBonus = double.MinValue;
            double attendancies = 0;
            double currAttendancesCount = 0;

            if (studentsCount == 0 || lecturesCount == 0)
            {
                Console.WriteLine($"Max Bonus: 0.");
                Console.WriteLine($"The student has attended 0 lectures.");
                return;
            }

            for (int i = 0; i < studentsCount; i++)
            {
                currAttendancesCount = int.Parse(Console.ReadLine());
                totalBonus = currAttendancesCount / lecturesCount * (5 + initialBonus);                

                if (totalBonus > maxBonus)
                {
                    maxBonus = totalBonus;
                    attendancies = currAttendancesCount;
                }
            }
            roundedTotalBonus = Math.Ceiling(maxBonus);
            Console.WriteLine($"Max Bonus: {roundedTotalBonus:f0}.");
            Console.WriteLine($"The student has attended {attendancies:f0} lectures.");
        }
    }
}
