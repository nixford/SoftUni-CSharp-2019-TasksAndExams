using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests
{
    public class FakeTarget : ITarget
    {
        public int Health => 0;

        public int GiveExperience()
        {
            return 10;
        }

        public bool IsDead()
        {
            return true;
        }

        public void TakeAttack(int attackPoints)
        {
            
        }
    }
}
