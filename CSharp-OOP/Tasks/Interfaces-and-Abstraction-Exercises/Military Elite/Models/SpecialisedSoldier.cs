using Military.Contracts;
using Military.Enumerations;
using Military.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, 
            string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary)
        {
            this.Corps = this.TryParceCorps(corps);
        }

        public Corps Corps { get; private set; }

        private Corps TryParceCorps(string corpsStr)
        {
            Corps corps;

            bool parsed = Enum.TryParse<Corps>(corpsStr, out corps);          

            if (!parsed)
            {
                throw new InvalidCorpsException();
            }
            return corps;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                $"Corps: {this.Corps.ToString()}";
        }
    }
}
