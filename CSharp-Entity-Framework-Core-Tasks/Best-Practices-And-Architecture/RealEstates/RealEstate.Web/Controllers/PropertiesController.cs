using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstates.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Web.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly IPropertiesService propertiesService;
        public PropertiesController(IPropertiesService propertiesService)
        {
            this.propertiesService = propertiesService;
        }

        public IActionResult Search()
        {
            return this.View();
        }

        //[Authorize(Roles = "Moderator")] - потребителят следва освен да се е логнал и да е модератор
        public IActionResult DoSearch(int minPrice, int maxPrice)
        {
            //if (!this.User.IsInRole("Admin"))
            //{
            //    return this.BadRequest();
            //}

            var viewPropertis = this.propertiesService.SearchByPrice(minPrice, maxPrice);
            return this.View(viewPropertis);
        }
    }
}
