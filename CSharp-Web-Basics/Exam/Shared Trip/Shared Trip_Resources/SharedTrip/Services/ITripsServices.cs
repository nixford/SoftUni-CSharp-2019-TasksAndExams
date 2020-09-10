using SharedTrip.Models;
using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;

namespace SharedTrip.Services
{
    public interface ITripsServices
    {
        void Add(TripAddInputModel tripAddInputModel);

        IEnumerable<TripDetailsViewModel> GetAll();

        Trip GetTrip(string id);

        bool AddUserToTrip(string tripId, string userId);
    }
}
