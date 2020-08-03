using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int PaladinPower = 100;

        public Paladin(string name, string heroType) 
            : base(name, heroType)
        {

        }

        public override int Power => PaladinPower;

        public override string CastAbility()
        {
            return base.CastAbility();
        }       
    }
}
