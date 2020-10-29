using SULS.Data;
using SULS.Models;
using SULS.ViewModels.Home;
using SULS.ViewModels.Problems;
using SULS.ViewModels.Submissions;
using System.Collections.Generic;
using System.Linq;

namespace SULS.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly ApplicationDbContext db;

        public ProblemsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(CreateInputModelProblem input)
        {
            var problem = new Problem
            {
                Name = input.Name,
                Points = input.TotalPoints,
                
            };
            this.db.Problems.Add(problem);
            this.db.SaveChanges();
        }

        public IEnumerable<HomePageProblemViewModel> GetAll()
        {
            var problems = this.db.Problems.Select(x => new HomePageProblemViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Count = x.Submissions.Count(),
            }).ToList();
            return problems;
        }

        public string GetNameById(string id)
        {
            return this.db.Problems
                .Where(x => x.Id == id)
                .Select(x => x.Name)
                .FirstOrDefault();
        }

        public ProblemDetailsViewModel GetById(string id)
        {
            return this.db.Problems.Where(x => x.Id == id)
                .Select(x => new ProblemDetailsViewModel
                {
                    Name = x.Name,
                    Submissions = x.Submissions.Select(s => new SubmissionViewModel
                    {
                        CreatedOn = s.CreatedOn,
                        SubmissionId = s.Id,
                        AchievedResult = s.AchievedResult,
                        Username = s.User.Username,
                        MaxPoints = x.Points,
                    })
                }).FirstOrDefault();
        }
    }
}
