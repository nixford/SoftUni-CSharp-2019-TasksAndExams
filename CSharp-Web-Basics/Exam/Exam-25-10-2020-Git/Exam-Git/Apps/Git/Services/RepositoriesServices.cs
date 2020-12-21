using Git.Data;
using Git.Models;
using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class RepositoriesServices : IRepositoriesServices
    {
        private readonly ApplicationDbContext db;

        public RepositoriesServices(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateRepository(User user, CreateRepositoryInputModel input)
        {
            var repository = new Repository()
            {
                Name = input.Name,
                IsPublic = input.RepositoryType == "Public" ? true : false,
                CreatedOn = DateTime.UtcNow,
                OwnerId = user.Id,
                Owner = user,
                Commits = new HashSet<Commit>(),
            };
            db.Repositories.Add(repository);
            db.SaveChanges();
        }

        public IEnumerable<RepositoryViewModel> GetAll()
        {
            return this.db.Repositories.Where(x => x.IsPublic == true)
               .Select(x => new RepositoryViewModel
               {
                   Id = x.Id,
                   Name = x.Name,
                   IsPublic = x.IsPublic,
                   CreatedOn = x.CreatedOn,
                   Owner = x.Owner,
                   Commits = x.Commits,
               }).ToList();
        }

        public User GetUserByUserId(string userId)
        {
            return this.db.Users.FirstOrDefault(x => x.Id == userId);
        }

        public Repository GetRepositoryById(string repositoryId)
        {
            return this.db.Repositories.FirstOrDefault(x => x.Id == repositoryId);
        }
    }
}
