using Raiding.Models;
using Raiding.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.HeroSchool
{
    public class HeroShool : IHeroSchool
    {       
        public IBaseHero CreateHero(string name, string heroType)
        {
            IBaseHero hero = null;

            if (heroType == nameof(Druid))
            {
                hero = new Druid(name, heroType);
            }
            else if (heroType == nameof(Paladin))
            {
                hero = new Paladin(name, heroType);
            }
            else if (heroType == nameof(Rogue))
            {
                hero = new Rogue(name, heroType);
            }
            else if (heroType == nameof(Warrior))
            {
                hero = new Warrior(name, heroType);
            }
            else
            {
                throw new ArgumentException(ExceptionMesseges.InvalidHeroMessage);
            }

            return hero;
        }

        
    }
}
