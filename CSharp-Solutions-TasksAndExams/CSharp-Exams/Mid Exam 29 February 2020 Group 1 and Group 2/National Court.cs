using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace National_Court
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstCountPerHour = int.Parse(Console.ReadLine());
            int secondCountPerHour = int.Parse(Console.ReadLine());
            int thirdCountPerHour = int.Parse(Console.ReadLine());
            int peopleCount = int.Parse(Console.ReadLine());

            int totalCapacityPerHour = firstCountPerHour + secondCountPerHour + thirdCountPerHour;
            int hourCount = 0;

            while (peopleCount > 0)
            {
                hourCount++;
                if (hourCount % 4 != 0)
                {
                    peopleCount -= totalCapacityPerHour;
                }       
            }
            Console.WriteLine($"Time needed: {hourCount}h.");
        }
    }
}
