using SharedTrip.Services;
using SharedTrip.ViewModels;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

            if (!isdepartureTimeValid || !IsValidObject(inputModel))
            {
                return this.Redirect($"/Trips/Add");
            }   

            this.tripsService.Add(inputModel);
            return this.Redirect("/Trips/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View(this.tripsService.GetAll());
        }

        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }            

            var trip = this.tripsService.GetTrip(tripId);
            var viewModel = new TripDetailsViewModel()
            {
                Id = trip.Id,
                ImagePath = trip.ImagePath,
                DepartureTime = trip.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                Seats = trip.Seats,
                StartPoint = trip.StartPoint,
                EndPoint = trip.EndPoint,
                Description = trip.Description,
            };

            return this.View(viewModel);
        }        

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.Request.SessionData["UserId"];
            var isAdded = this.tripsService.AddUserToTrip(tripId, userId);

            if (isAdded)
            {
                return this.Redirect("/Trips/All");
            }

            return this.Redirect($"/Trips/Details?tripId={tripId}");
        }

        private static bool IsValidObject(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}

