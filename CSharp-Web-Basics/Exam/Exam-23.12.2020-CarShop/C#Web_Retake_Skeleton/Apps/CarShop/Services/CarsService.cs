using CarShop.Data;
using CarShop.Data.Models;
using CarShop.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarShop.Services
{
    public class CarsService : ICarsService
    {
        private readonly ApplicationDbContext db;

        public CarsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddCar(string model, int year, string image, string plateNumber, string ownerId)
        {
            var car = new Car
            {
                Model = model,
                Year = year,
                PictureUrl = image,
                PlateNumber = plateNumber,
                OwnerId = ownerId,
                Issues = new HashSet<Issue>(),
            };

            db.Cars.Add(car);
            db.SaveChanges();
        }

        public IEnumerable<CarViewModel> GetAll()
        {
            return db.Cars
                .Select(x => new CarViewModel
                {
                    Id = x.Id,
                    Image = x.PictureUrl,
                    Model = x.Model,
                    Year = x.Year,
                    PlateNumber = x.PlateNumber,
                    RemainingIssues = x.Issues.Where(c => c.IsFixed == false).Count(),
                    FixedIssues = x.Issues.Where(c => c.IsFixed == true).Count(),
                }).ToList();
        }
    }
}
