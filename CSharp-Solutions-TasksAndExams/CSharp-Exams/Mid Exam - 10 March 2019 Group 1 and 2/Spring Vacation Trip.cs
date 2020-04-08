using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring_Vacation_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOfTrip = int.Parse(Console.ReadLine());
            double budged = double.Parse(Console.ReadLine());
            int peopleNumber = int.Parse(Console.ReadLine());
            double fuelPricePerKilo = double.Parse(Console.ReadLine());
            double foodExpencesPerPerson = double.Parse(Console.ReadLine());
            double roomPricePerPersonPerNight = double.Parse(Console.ReadLine());

            double foodExpenses = foodExpencesPerPerson * peopleNumber * daysOfTrip;
            double hotelExpenses = roomPricePerPersonPerNight * peopleNumber * daysOfTrip;
            // if the group is bigger than 10
            if (peopleNumber > 10)
            {
                hotelExpenses = hotelExpenses - (hotelExpenses * 0.25);
            }
            double totalExpenses = foodExpenses + hotelExpenses;           

            for (int i = 1; i <= daysOfTrip; i++)
            {
                if (totalExpenses >= budged)
                {                    
                    break;
                }
                double travelledDistanceKilo = double.Parse(Console.ReadLine());
                totalExpenses = totalExpenses + (travelledDistanceKilo * fuelPricePerKilo);              

                if (i % 3 == 0 || i % 5 == 0)
                {
                    totalExpenses = totalExpenses + (totalExpenses * 0.40);
                }

                if (i % 7 == 0)
                {
                    totalExpenses = totalExpenses - (totalExpenses / peopleNumber);
                }                
            }
            if (totalExpenses <= budged)
            {
                Console.WriteLine($"You have reached the destination. You have {budged - totalExpenses:f2}$ budget left.");
            }
            else
            {
                Console.WriteLine($"Not enough money to continue the trip. You need {totalExpenses - budged:f2}$ more.");
            }
        }
    }
}
