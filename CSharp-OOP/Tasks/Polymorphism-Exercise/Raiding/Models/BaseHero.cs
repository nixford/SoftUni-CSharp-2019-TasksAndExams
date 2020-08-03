using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public abstract class BaseHero : IBaseHero
    {
        public BaseHero(string name)
        {
            Name = name;
        }

        public BaseHero(string name, string heroType)
        {
            this.Name = name;
            this.HeroType = heroType;
        }
        public string Name { get; }
        public virtual int Power { get; protected set; }
        public string HeroType { get; set; }
        public virtual string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
