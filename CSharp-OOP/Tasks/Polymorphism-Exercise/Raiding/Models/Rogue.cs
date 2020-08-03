using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int RougePower = 80;

        public Rogue(string name, string heroType) 
            : base(name, heroType)
        {

        }

        public override int Power => RougePower;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
