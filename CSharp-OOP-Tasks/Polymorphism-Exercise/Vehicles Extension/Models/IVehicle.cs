﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        bool HasAirCondition { get; }

        double AirConditionConsumption { get; }

        double TankCapaCity { get; }

        bool Drive(double distance);

        void Refuel(double litters);

        void StartAirCondition();

        void StoptAirCondition();
    }
}
