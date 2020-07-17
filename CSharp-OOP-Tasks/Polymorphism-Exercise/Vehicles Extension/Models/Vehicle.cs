using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models;
using Vehicles.Utilities;

namespace Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private const double DefoultfuelQuantity = 0;

        private double fuelQuantity;
        protected Vehicle(double fuelQuantity, 
            double fuelConsumption, 
            double tankCapacity,
            bool hasAirCondition = true)
        {
            this.TankCapaCity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.HasAirCondition = hasAirCondition;            
        }
        public double FuelQuantity 
        { 
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                if (value > this.TankCapaCity)
                {
                    this.fuelQuantity = DefoultfuelQuantity;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption { get; }

        public bool HasAirCondition { get; private set; }

        public abstract double AirConditionConsumption { get; }

        public double TankCapaCity { get; }        

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
            if (litters <= 0)
            {
                throw new ArgumentException(ExceptionMesseges.NegativeFuelAmount);
            }

            if (this.FuelQuantity + litters > this.TankCapaCity)
            {
                string msg = string.Format(ExceptionMesseges.InvalidFuelAmount, litters);
                throw new ArgumentException(msg);
            }
            this.FuelQuantity += litters;
        }

        public void StartAirCondition()
        {
            this.HasAirCondition = true;
        }

        public void StoptAirCondition()
        {
            this.HasAirCondition = false;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
