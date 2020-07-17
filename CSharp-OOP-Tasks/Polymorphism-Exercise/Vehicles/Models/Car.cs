using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double DefaultAirCondConsump = 0.9;
        public Car(double fuelQuantity, 
            double fuelConsumption, 
            bool hasAirCondition = true) 
            : base(fuelQuantity, fuelConsumption, hasAirCondition)
        {
           
        }

        public override double AirConditionConsumption => DefaultAirCondConsump;
    }
}
