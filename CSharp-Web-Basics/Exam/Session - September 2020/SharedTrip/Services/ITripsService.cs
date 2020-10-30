using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        string Add(AddTripInputModel input);

        IEnumerable<TripViewModel> GetAll();        

        DetailsTripViewModel GetDetails(string id);

        void AddTripToUserCollection(string userId, string tripId);       
    }
}
