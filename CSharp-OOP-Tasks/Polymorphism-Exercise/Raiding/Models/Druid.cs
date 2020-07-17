using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int DruidPower = 80;
               

        public Druid(string name, string heroType) 
            : base(name, heroType)
        {

        }

        public override int Power => DruidPower;

        public override string CastAbility()
        {
            return base.CastAbility();
        }
    }
}
