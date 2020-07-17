using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Factories;
using Vehicles.IO;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
        {
            this.reader = reader; // FileReader();
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;
        }

        public void Run()
        {
            string[] carData = reader.CustomReadLine().Split(' ');
            IVehicle car = CreateVehicle(carData);

            string[] truckData = reader.CustomReadLine().Split(' ');
            IVehicle truck = CreateVehicle(truckData);

            string[] busData = reader.CustomReadLine().Split(' ');
            IVehicle bus = CreateVehicle(busData);

            int n = int.Parse(this.reader.CustomReadLine());


            for (int i = 0; i < n; i++)
            {
                string[] args = this.reader.CustomReadLine()
                    .Split(' ');
                string command = args[0];
                string vehicleType = args[1];
                double distanceOrLitters = double.Parse(args[2]);

                try
                {
                    if (command == "Drive")
                    {
                        DriveCommand(car, truck, bus, vehicleType, distanceOrLitters);
                    }
                    else if (command == "DriveEmpty")
                    {
                        DriveEmptyBus(bus, distanceOrLitters);
                    }
                    else if (command == "Refuel")
                    {
                        RefuelCommand(car, truck, bus, vehicleType, distanceOrLitters);
                    }
                }
                catch (ArgumentException ex)
                {
                    this.writer.CustomWriteLine(ex.Message);
                }                
            }
            this.writer.CustomWriteLine(car.ToString());
            this.writer.CustomWriteLine(truck.ToString());
            this.writer.CustomWriteLine(bus.ToString());
        }

        private void DriveEmptyBus(IVehicle bus, double distanceOrLitters)
        {
            bus.StoptAirCondition();
            bool isDrive = bus.Drive(distanceOrLitters);
            
            if (isDrive)
            {
                this.writer.CustomWriteLine($"Bus travelled {distanceOrLitters} km");
            }
            else
            {
                this.writer.CustomWriteLine($"Bus needs refueling");
            }
        }

        private static void RefuelCommand(IVehicle car, IVehicle truck, IVehicle bus, string vehicleType, double distanceOrLitters)
        {
            if (vehicleType == "Car")
            {
                car.Refuel(distanceOrLitters);
            }
            else if (vehicleType == "Truck")
            {
                truck.Refuel(distanceOrLitters);
            }
            else if (vehicleType == "Bus")
            {
                bus.Refuel(distanceOrLitters);
            }
        }

        private void DriveCommand(IVehicle car, IVehicle truck, IVehicle bus, string vehicleType, double distanceOrLitters)
        {
            bool isDrive = false;

            if (vehicleType == "Car")
            {
                isDrive = car.Drive(distanceOrLitters);
            }
            else if (vehicleType == "Truck")
            {
                isDrive = truck.Drive(distanceOrLitters);
            }
            else if (vehicleType == "Bus")
            {
                bus.StartAirCondition(); 
                isDrive = bus.Drive(distanceOrLitters);
            }

            if (isDrive)
            {
                this.writer.CustomWriteLine($"{vehicleType} travelled {distanceOrLitters} km");
            }
            else
            {
                this.writer.CustomWriteLine($"{vehicleType} needs refueling");
            }
        }

        private IVehicle CreateVehicle(string[] data)
        {
            string type = data[0];
            double fuelQuantity = double.Parse(data[1]);
            double consumptionPerKm = double.Parse(data[2]);
            double tankCapacity = double.Parse(data[3]);

            IVehicle vehicle = this.vehicleFactory.CreateVehicle(
                type,
                fuelQuantity,               
                consumptionPerKm,
                 tankCapacity);

            return vehicle;
        }
    }
}
