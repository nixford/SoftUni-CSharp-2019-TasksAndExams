using SharedTrip.Services;
using SharedTrip.ViewModels;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsServices tripsService;

        public TripsController(ITripsServices productsService)
        {
            this.tripsService = productsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(TripAddInputModel inputModel)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            DateTime departureTime;
            bool isdepartureTimeValid = DateTime.TryParseExact
                (inputModel.DepartureTime, "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None, out departureTime);

            if (!isdepartureTimeValid)
            {
                return this.View();
            }           

            if (string.IsNullOrEmpty(inputModel.Description) || inputModel.Description.Length > 10)
            {
                return this.View();
            }

            var tripId = this.tripsService.Add(inputModel);

            return this.Redirect($"/Trips/AddUserToTrip?tripId={tripId}");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var product = this.tripsService.GetById(id);

            return this.View(product);
        }       
    }
}
