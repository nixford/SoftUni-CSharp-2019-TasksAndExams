using Git.ViewModels.Repositories;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesServices repositoriesService;

        public RepositoriesController(IRepositoriesServices repositoriesService)
        {
            this.repositoriesService = repositoriesService;
        }

        // GET /repositories/add
        public HttpResponse All()
        {
            var viewModel = this.repositoriesService.GetAll();

            return this.View(viewModel);            
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");

            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateRepositoryInputModel model)
        {

            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(model.Name) || model.Name.Length < 3 || model.Name.Length > 10)
            {
                return this.Error("Name should be between 3 and 10 characters long.");
            }

            var userId = this.GetUserId();
            var user = this.repositoriesService.GetUserByUserId(userId);

            this.repositoriesService.CreateRepository(user, model);

            return this.Redirect("/Repositories/All");
        }
    }
}
