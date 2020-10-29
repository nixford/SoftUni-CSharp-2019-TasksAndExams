using SULS.Models;
using SULS.ViewModels.Home;
using SULS.ViewModels.Problems;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.Services
{
    public interface IProblemsService
    {
        void Create(CreateInputModelProblem input);

        IEnumerable<HomePageProblemViewModel> GetAll();

        string GetNameById(string id);

        ProblemDetailsViewModel GetById(string id);
    }
}
