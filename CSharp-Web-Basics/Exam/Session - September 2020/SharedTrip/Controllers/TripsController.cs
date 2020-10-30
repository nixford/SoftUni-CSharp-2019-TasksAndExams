using SharedTrip.Models;
using SharedTrip.Services;
using SharedTrip.ViewModels.Trips;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Linq;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripService;        

        public TripsController(ITripsService tripService)
        {
            this.tripService = tripService;            
        }        

        // GET /trips/add
        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddTripInputModel model)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(model.StartPoint))
            {
                return this.Error("Start Point is requred!");
            }

            if (string.IsNullOrEmpty(model.EndPoint))
            {
                return this.Error("End Point is requred!");
            }

            if (model.DepartureTime == null)
            {
                return this.Error("Departure time is requred!");
            }

            if (model.Seats < 2 || model.Seats > 6)
            {
                return this.Error("Seats must be between 2 and 6!");
            }

            if (string.IsNullOrWhiteSpace(model.Description) || model.Description.Length > 200)
            {
                return this.Error("Description is required and its length should be at most 200 characters.");
            }

            if (string.IsNullOrWhiteSpace(model.ImagePath))
            {
                return this.Error("The image is required!");
            }

            this.tripService.Add(model);
            return this.Redirect("/Trips/All");
        }

        // /trips/all
        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = tripService.GetAll();
            return this.View(viewModel);
        }

        public HttpResponse Details(string tripId)
        {
            var viewModel = this.tripService.GetDetails(tripId);
            return this.View(viewModel);
        }       

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            this.tripService.AddTripToUserCollection(userId, tripId);
            return this.Redirect("/");
        }
    }
}
