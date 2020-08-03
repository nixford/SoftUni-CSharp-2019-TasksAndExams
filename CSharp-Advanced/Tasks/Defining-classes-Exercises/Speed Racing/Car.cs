using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        string model;
        double fuelAmount;
        double fuelConsumptionPerKilometer;
        double travelledDistance;
        public string Model 
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }        
        }        
        public double FuelAmount
        {
            get
            {
                return this.fuelAmount;
            }
            set
            {
                this.fuelAmount = value;
            }
        }
        public double FuelConsumptionPerKilometer
        {
            get
            {
                return this.fuelConsumptionPerKilometer;
            }
            set
            {
                this.fuelConsumptionPerKilometer = value;
            }
        }
        public double TravelledDistance
        {
            get
            {
                return this.travelledDistance;
            }
            set
            {
                this.travelledDistance = value;
            }
        }

        public Car()
        {

        }
        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumption;
            this.TravelledDistance = 0;
        }

        public void GetCheckEnoughFuel(
            string model, 
            double distance)
        {
            double neededLitres = distance * this.FuelConsumptionPerKilometer;

            if (this.FuelAmount >= neededLitres)
            {
                this.fuelAmount -= neededLitres;
                this.TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount} {this.TravelledDistance}";
        }
    }
}
