using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int carNumber = int.Parse(Console.ReadLine());
            
            List<Car>carList = new List<Car>();
          
            for (int i = 0; i < carNumber; i++)
            {
                string[] carArgs = Console.ReadLine()
                    .Split()
                    .ToArray();
                string model = carArgs[0];
                double fuelAmount = double.Parse(carArgs[1]);
                double fuelConsumptionFor1km = double.Parse(carArgs[2]);

                Car currentCar = new Car(model, fuelAmount, fuelConsumptionFor1km);

                carList.Add(currentCar);
            }

            string commands = string.Empty;
            while ((commands = Console.ReadLine()) != "End")
            {
                string[] commandsArgs = commands
                    .Split(' ')
                    .ToArray();
                string carModel = commandsArgs[1];
                double distance = double.Parse(commandsArgs[2]);

                Car carForDriving = carList
                       .Where(x => x.Model == carModel)
                       .ToList()
                       .First();

                carForDriving.GetCheckEnoughFuel(carModel, distance);
            }

            foreach (var item in carList)
            {
                Console.WriteLine($"{ item.Model} { item.FuelAmount:F2} {item.TravelledDistance}");
            }
        }
    }
}
