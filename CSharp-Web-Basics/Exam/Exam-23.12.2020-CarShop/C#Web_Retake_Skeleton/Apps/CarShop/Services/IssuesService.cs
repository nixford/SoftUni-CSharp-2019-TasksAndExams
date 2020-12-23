using CarShop.Data;
using CarShop.Data.Models;
using CarShop.ViewModels.Issues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarShop.Services
{
    public class IssuesService : IIssuesService
    {
        private readonly ApplicationDbContext db;

        public IssuesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddIssue(string description, string carId)
        {
            var ussue = new Issue
            {
                Description = description,
                CarId = carId,
            };

            this.db.Issues.Add(ussue);
            this.db.SaveChanges();
        }

        public IEnumerable<IssuesViewModel> GetAllCarIssues(string carId)
        {
            return db.Issues
                   .Select(x => new IssuesViewModel
                   {
                       IssueId = x.Id,
                       Description = x.Description,
                       IsFixed = x.IsFixed,                       
                   }).ToList();
        }

        public void DeleteIssue(string issueId, string carId)
        {
            var car = this.db.Cars.FirstOrDefault(c => c.Id == carId);

            var issue = this.db.Issues.FirstOrDefault(i => i.Id == issueId);

            this.db.Issues.Remove(issue);
            this.db.SaveChanges();
        }

        public void FixIssue(string issueId, string carId)
        {
            var car = this.db.Cars.FirstOrDefault(c => c.Id == carId);

            var issue = this.db.Issues.FirstOrDefault(i => i.Id == issueId);

            issue.IsFixed = true;

            this.db.Issues.Update(issue);

            this.db.SaveChanges();
        }        
    }
}
