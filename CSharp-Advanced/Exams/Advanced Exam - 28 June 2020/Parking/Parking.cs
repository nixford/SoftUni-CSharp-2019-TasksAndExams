﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new List<Car>();
        }

        public int Count => this.data.Count;

        public string Type { get; set; }

        public int Capacity { get; set; }

        public void Add(Car car)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            if (this.data.Any(c => c.Manufacturer == manufacturer && c.Model == model))
            {
                foreach (Car car in this.data)
                {
                    if (car.Manufacturer == manufacturer && car.Model == model)
                    {
                        this.data.Remove(car);
                        break;
                    }
                }
                return true;
            }
            return false;            
        }

        public Car GetLatestCar()
        {
            if (this.data.Any())
            {
                Car car = this.data.OrderByDescending(c => c.Year).FirstOrDefault();
                return car;
            }
            return null;
        }

        public Car GetCar(string manufacturer, string model)
        {
            if (this.data.Any(c => c.Manufacturer == manufacturer && c.Model == model))
            {
                Car car = this.data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
                return car;
            }
            return null;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"The cars are parked in {this.Type}:");

            foreach (Car car in this.data)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
