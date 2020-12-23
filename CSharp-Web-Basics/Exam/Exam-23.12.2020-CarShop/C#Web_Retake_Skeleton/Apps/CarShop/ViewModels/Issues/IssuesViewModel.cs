using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.ViewModels.Issues
{
    public class IssuesViewModel
    {
        public string MyProperty { get; set; }

        public string IssueId { get; set; }

        public string Description { get; set; }        

        public bool IsFixed { get; set; }

        public string Fixed => IsFixed == true ? "Yes" : "Not yet!";
    }
}
