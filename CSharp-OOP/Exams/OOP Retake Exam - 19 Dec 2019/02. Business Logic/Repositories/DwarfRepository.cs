﻿ using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Repositories
{
    public class DwarfRepository : IRepository<IDwarf>
    {
        private readonly ICollection<IDwarf> models;

        public DwarfRepository()
        {
            this.models = new List<IDwarf>();
        }

        public IReadOnlyCollection<IDwarf> Models =>
            (IReadOnlyCollection<IDwarf>)this.models;

        public void Add(IDwarf model)
        {
            if (!models.Contains(model))
            {
                this.models.Add(model);
            }            
        }

        public bool Remove(IDwarf model)
        {
            return this.models.Remove(model);
        }

        public IDwarf FindByName(string name)
        {
            return this.models.FirstOrDefault(d => d.Name == name);
        }        
    }
}
