using System;
using System.Linq;

namespace HotelReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .ToArray();

            PriceCalculator calculator = new PriceCalculator();

            decimal pricePerDay = decimal.Parse(input[0]);
            int numberOfDays = int.Parse(input[1]);
            string season = input[2];
            string discount = "None";
            if (input.Length > 3)
            {
                discount = input[3];
            }

            decimal result = calculator.CalculatePrice(
                pricePerDay, 
                numberOfDays,
                Enum.Parse<SeasonMultiplier>(season),
                Enum.Parse<DiscountPercentage>(discount));

            Console.WriteLine($"{result:f2}");

        }
    }
}
