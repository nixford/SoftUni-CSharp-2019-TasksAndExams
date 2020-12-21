using Git.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.ViewModels.Repositories
{
    public class RepositoryViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsPublic { get; set; }

        public User Owner { get; set; }

        public int CommitsCount => this.Commits.Count();

        public virtual ICollection<Commit> Commits { get; set; }
    }
}
