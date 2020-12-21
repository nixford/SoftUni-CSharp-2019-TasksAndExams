using Git.Models;
using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface ICommitsServices
    {
        void Create(User user, CreateCommitInputModel input);

        IEnumerable<CommitsViewModel> GetAll(string id);

        void DeleteById(string id, string userId);
    }
}
