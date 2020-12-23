using CarShop.ViewModels.Issues;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Services
{
    public interface IIssuesService
    {
        void AddIssue(string description, string carId);

        IEnumerable<IssuesViewModel> GetAllCarIssues(string carId);

        void FixIssue(string issueId, string carId);

        void DeleteIssue(string issueId, string carId);
    }
}
