using Git.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Git.ViewModels.Repositories
{
    public class CreateRepositoryInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Name { get; set; }

        [Required]
        public string RepositoryType { get; set; }
    }
}
