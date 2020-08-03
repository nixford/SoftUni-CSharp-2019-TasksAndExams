using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Utilities;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double DefaultAirCondConsump = 1.6;
        private const double RefuelPercentage = 0.95;
        public Truck(
            double fuelQuantity, 
            double fuelConsumption,
            double tankCapacity,
            bool hasAirCondition = true) 
            : base(
                  fuelQuantity, 
                  fuelConsumption,
                  tankCapacity,
                  hasAirCondition)
        {

        }

        public override double AirConditionConsumption => DefaultAirCondConsump;

        public override void Refuel(double litters)
        {
            //this.FuelQuantity += liters * RefuelPercentage;

            if (litters <= 0)
            {
                throw new ArgumentException(ExceptionMesseges.NegativeFuelAmount);
            }

            if (this.FuelQuantity + litters > this.TankCapaCity)
            {
                string msg = string.Format(ExceptionMesseges.InvalidFuelAmount, litters);
                throw new ArgumentException(msg);
            }
            base.Refuel(litters * RefuelPercentage);
        }
    }
}
