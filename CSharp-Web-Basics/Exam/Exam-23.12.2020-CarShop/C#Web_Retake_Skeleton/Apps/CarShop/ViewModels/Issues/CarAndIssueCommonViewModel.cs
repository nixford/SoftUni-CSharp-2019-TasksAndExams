using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.ViewModels.Issues
{
    public class CarAndIssueCommonViewModel
    {
        public string CarId { get; set; }

        public string CarModel { get; set; }

        public int CarYear { get; set; }

        public IEnumerable<IssuesViewModel> Issues { get; set; }
    }
}
