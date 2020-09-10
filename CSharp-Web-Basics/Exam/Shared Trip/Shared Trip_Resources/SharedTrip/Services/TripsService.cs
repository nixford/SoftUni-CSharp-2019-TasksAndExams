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


        public void Add(TripAddInputModel tripAddInputModel)
        {
            var trip = new Trip()
            {
                Id = Guid.NewGuid().ToString(),
                StartPoint = tripAddInputModel.StartPoint,
                EndPoint = tripAddInputModel.EndPoint,
                DepartureTime = DateTime.ParseExact(tripAddInputModel.DepartureTime,
                "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImagePath = tripAddInputModel.ImagePath,
                Seats = tripAddInputModel.Seats,
                Description = tripAddInputModel.Description,                
            };

            this.dbContext.Trips.Add(trip);
            this.dbContext.SaveChanges();            
        }

        public IEnumerable<TripDetailsViewModel> GetAll()
        {
            var trips = this.dbContext.Trips.Select(t => new TripDetailsViewModel
            {
                Id = t.Id,
                Seats = t.Seats,
                DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                StartPoint = t.StartPoint,
                EndPoint = t.EndPoint,
            }).ToArray();            

            return trips;
        }       

        public bool AddUserToTrip(string tripId, string userId)
        {
            var targetTrip = this.dbContext.Trips.FirstOrDefault(x => x.Id == tripId);
            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = userId
            };
            
            if (!this.dbContext.UserTrips.Any(x => x.TripId == userTrip.TripId && x.UserId == userTrip.UserId) && targetTrip.Seats > 0)
            {
                targetTrip.Seats -= 1;
                targetTrip.UserTrips.Add(userTrip);
                dbContext.SaveChanges();
                return true;
            }

            return false;
        }

        public Trip GetTrip(string tripId) =>
            this.dbContext.Trips.FirstOrDefault(t => t.Id == tripId);
    }
}
