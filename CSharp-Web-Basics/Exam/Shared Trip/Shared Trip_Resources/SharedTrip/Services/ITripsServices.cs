using SharedTrip.Models;
using SharedTrip.ViewModels;
using System.Collections.Generic;

namespace SharedTrip.Services
{
    public interface ITripsServices
    {
        string Add(TripAddInputModel tripAddInputModel);

        IEnumerable<Trip> GetAll();

        Trip GetById(string id);        
    }
}
