using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models;

namespace Vehicles.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle(
            string type, 
            double fuelQuantity, 
            double fuelConsumption,
            double tankCapacity,
            bool hasAirCondition = true)
        {
            IVehicle vehicle = null;

            if (type == nameof(Car))
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity, hasAirCondition);
            }
            else if (type == nameof(Truck))
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity, hasAirCondition);
            }
            else if (type == nameof(Bus))
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity, hasAirCondition);
            }

            return vehicle;
        }

       
    }
}
