using System;
using System.Collections.Generic;
using System.Linq;

namespace Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            HashSet<string> cars = new HashSet<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputLine = input.Split(new[] { ", " }, 
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string direction = inputLine[0];
                string carNumber = inputLine[1];

                if (direction == "IN")
                {
                    cars.Add(carNumber);
                }
                else // direction == "OUT"
                {
                    cars.Remove(carNumber);
                }
            }

            if (cars.Any())
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }            
        }
    }
}
