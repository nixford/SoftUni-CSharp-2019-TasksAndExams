using SULS.Data;
using SULS.Models;
using SULS.Services;
using SULS.ViewModels.Problems;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Linq;

namespace SULS.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;
        private readonly ApplicationDbContext db;

        public ProblemsController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
            this.db = db;
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
        public HttpResponse Create(CreateInputModelProblem input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(input.Name) || input.Name.Length < 5 || input.Name.Length > 20)
            {
                return this.Error("Name should be with length between 5 and 20");
            }

            if (input.TotalPoints < 50 || input.TotalPoints > 300)
            {
                return this.Error("Total points should be with length between 50 and 300");
            }            

            this.problemsService.Create(input);
            return this.Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.db.Problems.Where(x => x.Id == id).Select(
                x => new DetailsViewModel
                {
                    Name = x.Name,
                    Problems = x.Submissions.Select(s =>
                    new ProblemDetailsSubmissionViewModel
                    {
                        CreatedOn = s.CreatedOn,
                        AchievedResult = s.AchievedResult,
                        SubmissionId = s.Id,
                        MaxPoints = x.Points,
                        Username = s.User.Username,
                    })
                }).FirstOrDefault();

            return this.View(viewModel);
        }
    }
}
