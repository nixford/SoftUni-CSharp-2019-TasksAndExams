using Git.Models;
using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface IRepositoriesServices
    {
        void CreateRepository(User user, CreateRepositoryInputModel input);

        IEnumerable<RepositoryViewModel> GetAll();

        User GetUserByUserId(string userId);

        Repository GetRepositoryById(string repositoryId);
    }
}