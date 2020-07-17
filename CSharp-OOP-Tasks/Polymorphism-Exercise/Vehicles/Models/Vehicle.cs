using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models;

namespace Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, 
            double fuelConsumption, 
            bool hasAirCondition = true)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.HasAirCondition = hasAirCondition;
        }
        public double FuelQuantity { get; protected set; }

        public double FuelConsumption { get; }

        public bool HasAirCondition { get; }

        public abstract double AirConditionConsumption { get; }

        public bool Drive(double distance)
        {
            double spentFuel = distance * this.FuelConsumption;

            if (this.HasAirCondition)
            {
                spentFuel += AirConditionConsumption * distance;
            }

            if (this.FuelQuantity < spentFuel)
            {
                return false;
            }
            this.FuelQuantity -= spentFuel;
            return true;
        } 

        public virtual void Refuel(double litters)
        {
            this.FuelQuantity += litters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
