using Microsoft.Data.SqlClient.Server;
using SharedTrip.Models;
using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SharedTrip.Services
{
    public class TripsService : ITripsServices
    {
        private readonly ApplicationDbContext dbContext;

        public TripsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public string Add(TripAddInputModel tripAddInputModel)
        {           

            var trip = new Trip()
            {
                Id = Guid.NewGuid().ToString(),
                StartPoint = tripAddInputModel.StartPoint,
                EndPoint = tripAddInputModel.EndPoint,
                DepartureTime = DateTime.ParseExact(tripAddInputModel.DepartureTime, 
                "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None),
                Seats = tripAddInputModel.Seats,
                Description = tripAddInputModel.Description,
                ImagePath = tripAddInputModel.ImagePath,
            };

            this.dbContext.Trips.Add(trip);
            this.dbContext.SaveChanges();

            return trip.Id;
        }       

        public IEnumerable<Trip> GetAll()
            => this.dbContext.Trips.Select(x => new Trip
            {
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint,
                DepartureTime = x.DepartureTime,
                Seats = x.Seats,
            })
            .ToArray();

        public Trip GetById(string id)
            => this.dbContext.Trips.FirstOrDefault(x => x.Id == id);       
    }
}
