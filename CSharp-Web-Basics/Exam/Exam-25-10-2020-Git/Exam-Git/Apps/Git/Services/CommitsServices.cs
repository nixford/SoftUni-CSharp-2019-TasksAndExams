using Git.Data;
using Git.Models;
using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class CommitsServices : ICommitsServices
    {
        private readonly ApplicationDbContext db;

        public CommitsServices(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(User user, CreateCommitInputModel input)
        {
            var repository = db.Repositories.FirstOrDefault(r => r.Id == input.Id);

            var commit = new Commit
            {
                Repository = repository,
                CreatedOn = DateTime.UtcNow,
                CreatorId = user.Id,
                Description = input.Description,
            };
            db.Commits.Add(commit);
            db.SaveChanges();
        }

        public void DeleteById(string id, string userId)
        {
            var commit = this.db.Commits.FirstOrDefault(x => x.Id == id && x.CreatorId == userId);
            if (commit == null)
            {
                return;
            }

            this.db.Commits.Remove(commit);
            this.db.SaveChanges();
        }

        public IEnumerable<CommitsViewModel> GetAll(string userId)
        {
            var commits = this.db.Commits
                .Where(c => c.CreatorId == userId)
                .Select(x => new CommitsViewModel 
                {
                    Id = x.Id,
                    RepositoryName = x.Repository.Name,
                    Description = x.Description,
                    CreatedOn = x.CreatedOn,
                })
                .ToList();

            return commits;
        }
    }
}
