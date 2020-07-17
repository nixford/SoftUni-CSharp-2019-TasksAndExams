using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double DefaultAirCondConsump = 0.9;
        public Car(
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
    }
}
