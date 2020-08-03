using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealEstate.Web.Models;
using RealEstates.Services;

namespace RealEstate.Web.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly IDistrictService districstService;

        public HomeController(IDistrictService districtService)
        {
            this.districstService = districtService;
        }

        public IActionResult Index()
        {
            var districts = this.districstService.GetTopDistrictsByAvaragePrice(100);

            return View(districts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
