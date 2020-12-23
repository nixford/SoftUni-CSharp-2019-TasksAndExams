using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarShop.ViewModels.Issues
{
    public class AddIssueInputModel
    {
        public string CarId { get; set; }

        [Required]
        [MinLength(5)]
        public string Description { get; set; }
    }
}
