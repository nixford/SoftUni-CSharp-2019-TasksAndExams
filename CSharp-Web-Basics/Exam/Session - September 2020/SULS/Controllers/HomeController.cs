﻿using SULS.Services;
using SULS.ViewModels.Home;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SULS.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProblemsService problemsService;

        public HomeController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserSignedIn())
            {
                var viewModel = this.problemsService.GetAll();                
                return this.View(viewModel, "IndexLoggedIn");
            }

            return this.View();
        }        
    }
}