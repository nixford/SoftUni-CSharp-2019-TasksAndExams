using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace Raiding.HeroSchool
{
    public interface IHeroSchool
    {
        IBaseHero CreateHero(string name, string heroType);
    }
}
