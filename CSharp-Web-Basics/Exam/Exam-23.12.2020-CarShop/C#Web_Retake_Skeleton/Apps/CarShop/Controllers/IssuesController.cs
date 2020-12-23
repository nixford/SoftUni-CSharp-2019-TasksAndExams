using CarShop.Services;
using CarShop.ViewModels.Issues;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IssuesService issuesService;
        private readonly ICarsService carsService;
        private readonly IUsersService usersService;

        public IssuesController(ICarsService carsService, IUsersService usersService, IssuesService issuesService)
        {
            this.carsService = carsService;
            this.usersService = usersService;
            this.issuesService = issuesService;
        }

        public HttpResponse CarIssues(string carId)
        {
            var viewModelCommon = new CarAndIssueCommonViewModel();

            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var car = this.carsService.GetAll().FirstOrDefault(c => c.Id == carId);

            viewModelCommon.Issues = this.issuesService.GetAllCarIssues(carId);

            viewModelCommon.CarModel = car.Model;
            viewModelCommon.CarYear = car.Year;
            viewModelCommon.CarId = car.Id;

            return this.View(viewModelCommon);
        }

       
        public HttpResponse Add(string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var car = this.carsService.GetAll().FirstOrDefault(c => c.Id == carId);

            return this.View(car);
        }

        [HttpPost]
        public HttpResponse Add(AddIssueInputModel model)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(model.Description) || model.Description.Length < 5)
            {
                return this.Error("Description should be at least 5 characters long!");
            }            

            this.issuesService.AddIssue(model.Description, model.CarId);

            return this.Redirect($"/Issues/CarIssues?carId={model.CarId}");
        }

        public HttpResponse Delete(string issueId, string CarId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.issuesService.DeleteIssue(issueId, CarId);

            return this.Redirect($"/Issues/CarIssues?carId={CarId}");
        }

        public HttpResponse Fix(string issueId, string CarId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            var user = this.usersService.GetUserByUserId(userId);

            if (user.IsMechanic == false)
            {
                return this.Error("Only mechanic can fix issue!");
            }

            this.issuesService.FixIssue(issueId, CarId);

            return this.Redirect($"/Issues/CarIssues?carId={CarId}");
        }

    }
}
