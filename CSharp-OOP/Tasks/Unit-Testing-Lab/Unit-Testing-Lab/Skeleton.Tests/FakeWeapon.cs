﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests
{
    public class FakeWeapon : IWeapon
    {
        public int AttackPoints => 10;

        public int DurabilityPoints => 10;

        public void Attack(ITarget target)
        {
             
        }
    }
}
