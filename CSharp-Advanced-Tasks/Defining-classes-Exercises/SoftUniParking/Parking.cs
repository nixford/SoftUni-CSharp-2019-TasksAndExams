using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }

        private Dictionary<string, Car> cars;
        private int capacity; 
        
        public int Count
        {
            get { return cars.Count; }
        }
        public Parking(int capacity)
        {
            this.capacity = capacity;
            cars = new Dictionary<string, Car>();            
        }
        public string AddCar(Car car)
        {
            if (cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (cars.Count == capacity)
            {
                return "Parking is full!";
            }

            cars.Add(car.RegistrationNumber, car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }
        public string RemoveCar(string RegistrationNumber)
        {
            if (!cars.ContainsKey(RegistrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            cars.Remove(RegistrationNumber);
            return $"Successfully removed {RegistrationNumber}";
        }
        public Car GetCar(string RegistrationNumber)
        {
            Car car = null;

            if (cars.ContainsKey(RegistrationNumber))
            {
                car = cars[RegistrationNumber];
            }
            return car;
        }
        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var registrationNumber in RegistrationNumbers)
            {
                RemoveCar(registrationNumber);
            }
        }
    }    
}
