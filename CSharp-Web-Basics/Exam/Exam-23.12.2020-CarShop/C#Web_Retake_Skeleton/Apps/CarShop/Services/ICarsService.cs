using CarShop.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Services
{
    public interface ICarsService
    {
        void AddCar(string model, int year, string image, string plateNumber, string ownerId);

        IEnumerable<CarViewModel> GetAll();
    }
}
