using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string Add(AddTripInputModel input)
        {
            var date = input.DepartureTime;

            DateTime departureOpenDate;
            bool isDearturenDateValid = DateTime.TryParseExact
                (date, "MM/dd/yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None, out departureOpenDate);

            var trip = new Trip
            {
                StartPoint = input.StartPoint,
                EndPoint = input.EndPoint,
                DepartureTime = departureOpenDate,
                ImagePath = input.ImagePath,
                Seats = input.Seats,
                Description = input.Description,
            };
            this.db.Trips.Add(trip);
            this.db.SaveChanges();
            return trip.Id;
        }

        public IEnumerable<TripViewModel> GetAll()
        {
            return this.db.Trips.Select(x => new TripViewModel
            {
                Id = x.Id,
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint,
                DepartureTime = x.DepartureTime.ToString(),
                Seats = x.Seats,
            }).ToList();
        }

        public DetailsTripViewModel GetDetails(string tripId)
        {
            // var selectedTrip = this.db.Trips.FirstOrDefault(x => x.Id == tripId);
            // string dateTime = selectedTrip.DepartureTime.ToString("MM/dd/yyyy HH:mm");

            var trip = this.db.Trips.Where(x => x.Id == tripId)
                .Select(x => new DetailsTripViewModel
                {
                    Id = x.Id,
                    ImagePath = x.ImagePath,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString("MM/dd/yyyy HH:mm"),
                    Seats = x.Seats,
                    Description = x.Description,

                }).FirstOrDefault();
            return trip;
        }

        public void AddTripToUserCollection(string userId, string tripId)
        {
            if (this.db.UserTrips.Any(x => x.UserId == userId && x.TripId == tripId))
            {
                return;
            }

            this.db.UserTrips.Add(new UserTrip
            {
                TripId = tripId,
                UserId = userId,
            });

            var selectedTrip = this.db.Trips.FirstOrDefault(x => x.Id == tripId);
            var currentSeats = selectedTrip.Seats;

            if (currentSeats != 0)
            {
                selectedTrip.Seats = currentSeats - 1;
            }

            this.db.Trips.Update(selectedTrip);
            this.db.SaveChanges();
        }        
    }
}
