using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double DefaultAirCondConsump = 1.4;
        public Bus(
            double fuelQuantity, 
            double fuelConsumption, 
            double tankCapacity,
            bool hasAirCondition = true) 
            : base(fuelQuantity, fuelConsumption, tankCapacity, hasAirCondition)
        {

        }

        public override double AirConditionConsumption => DefaultAirCondConsump;
    }
}
