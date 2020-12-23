using CarShop.Services;
using CarShop.ViewModels.Cars;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {

        private readonly ICarsService carsService;
        private readonly IUsersService usersService;

        public CarsController(ICarsService carsService, IUsersService usersService)
        {
            this.carsService = carsService;
            this.usersService = usersService;
        }

        // GET /cards/add
        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            if (this.usersService.IsUserMechanic(userId))
            {
                return this.Error("The user must be client in order to have access to the add car page!");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(string model, int year, string image, string plateNumber)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            if (this.usersService.IsUserMechanic(userId))
            {
                return this.Error("The user must be client in order to have access to the add car page!");
            }

            if (string.IsNullOrEmpty(model) || model.Length < 5 || model.Length > 20)
            {
                return this.Error("Model should be between 5 and 20 characters long.");
            }

            if (year < 1900 || year > DateTime.UtcNow.Year)
            {
                return this.Error("The year should be between 1900 and the present year!");
            }

            if (!Uri.TryCreate(image, UriKind.Absolute, out _))
            {
                return this.Error("Image url should be valid.");
            }

            if (string.IsNullOrWhiteSpace(plateNumber))
            {
                return this.Error("The plate number is required!");
            }

            if (!Regex.IsMatch(plateNumber, @"^[A-z]{2} [0-9]{4} [A-Z]{2}$"))
            {
                return this.Error("The valid plate number must have 2 Capital English letters, followed by interval, followed by 4 digits, followed by interval, followed by 2 Capital English letters!");
            }

            

            this.carsService.AddCar(model, year, image, plateNumber, userId);

            return this.Redirect("/Cars/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var carsViewModel = this.carsService.GetAll();
            return this.View(carsViewModel);
        }
    }
}
