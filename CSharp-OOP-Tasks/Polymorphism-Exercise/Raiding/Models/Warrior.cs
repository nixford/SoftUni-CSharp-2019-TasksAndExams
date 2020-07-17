﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int WarriorPower = 100;

        public Warrior(string name, string heroType) 
            : base(name, heroType)
        {

        }

        public override int Power => WarriorPower;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
