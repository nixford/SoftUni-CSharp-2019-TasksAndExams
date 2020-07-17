using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double DefaultAirCondConsump = 1.6;
        private const double RefuelPercentage = 0.95;
        public Truck(double fuelQuantity, 
            double fuelConsumption, 
            bool hasAirCondition = true) 
            : base(fuelQuantity, fuelConsumption, hasAirCondition)
        {

        }

        public override double AirConditionConsumption => DefaultAirCondConsump;

        public override void Refuel(double litters)
        {
            //this.FuelQuantity += liters * RefuelPercentage;
            base.Refuel(litters * RefuelPercentage);
        }
    }
}
