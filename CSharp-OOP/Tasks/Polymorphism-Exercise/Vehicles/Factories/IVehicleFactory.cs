using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models;

namespace Vehicles.Factories
{
    public interface IVehicleFactory
    {
        IVehicle CreateVehicle(string type, double fuelQuantity,
            double fuelConsumption,
            bool hasAirCondition = true);
    }
}
