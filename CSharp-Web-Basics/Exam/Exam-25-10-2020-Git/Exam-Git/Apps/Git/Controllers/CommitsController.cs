using Git.Services;
using Git.ViewModels.Commits;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitsServices commitssService;
        private readonly IRepositoriesServices repositoriesService;

        public CommitsController(
            IRepositoriesServices repositoriesService, 
            ICommitsServices commitssService)
        {
            this.repositoriesService = repositoriesService;
            this.commitssService = commitssService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            var viewModel = this.commitssService.GetAll(userId);

            return this.View(viewModel);
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");

            }

            var viewModel = this.repositoriesService.GetRepositoryById(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(CreateCommitInputModel model)
        {

            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(model.Description) || model.Description.Length < 5)
            {
                return this.Error("Description should be more than 5 characters long.");
            }

            var userId = this.GetUserId();
            var user = this.repositoriesService.GetUserByUserId(userId);

            this.commitssService.Create(user, model);

            return this.Redirect("/Repositories/All");
        }

        public HttpResponse Delete(string id)
        {

            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            this.commitssService.DeleteById(id, userId);

            return this.Redirect("/Commits/All");
        }
    }
}
