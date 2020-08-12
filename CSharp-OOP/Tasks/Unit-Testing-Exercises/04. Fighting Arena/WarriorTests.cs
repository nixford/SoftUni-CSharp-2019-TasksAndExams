//using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior1;
        private Warrior warrior2;
        private Warrior warrior3;
        private Warrior warrior4;

        [SetUp]
        public void Setup()
        {
            warrior1 = new Warrior("Doro", 35, 100);
            warrior2 = new Warrior("Boro", 31, 33);
            warrior3 = new Warrior("Joro", 10, 10);
            warrior4 = new Warrior("Toro", 10, 100);
        }

        [Test]
        public void Test_Warrior_Constructor()
        {
            Assert.AreEqual("Doro", warrior1.Name);
            Assert.AreEqual(35, warrior1.Damage);
            Assert.AreEqual(100, warrior1.HP);           
        }

        [Test]
        public void Test_Name_Null()
        {
            Assert.Throws<ArgumentException>(() 
                => this.warrior1 = new Warrior(null, 35, 100));
        }

        [Test]
        public void Test_Damage_MustBePositive()
        {
            Assert.Throws<ArgumentException>(()
                => this.warrior1 = new Warrior("Doro", 0, 100));
        }

        [Test]
        public void Test_HP_MustBeZeroOrPositive()
        {
            Assert.Throws<ArgumentException>(()
                => this.warrior1 = new Warrior("Doro", 35, -1));
        }

        [Test]
        public void Test_Attack_ForMinHP()
        {
            Assert.Throws<InvalidOperationException>(()
                => warrior3.Attack(warrior1));
        }

        [Test]
        public void Test_Attack_ForMinEnemyHP()
        {
            Assert.Throws<InvalidOperationException>(()
                => warrior1.Attack(warrior3));
        }

        [Test]
        public void Test_Attack_ForTooStrongHeroToAttack()
        {
            Assert.Throws<InvalidOperationException>(()
                => warrior3.Attack(warrior1));
        }

        [Test]
        public void Test_Attack_This_HP()
        {
            Warrior warrior1 = new Warrior("Doro", 41, 35);
            Warrior warrior2 = new Warrior("Boro", 34, 40);
            warrior1.Attack(warrior2);
            Assert.AreEqual(1, warrior1.HP);
        }

        [Test]
        public void Test_Attack_If_Statment()
        {
            // Arrange            

            // Act
            this.warrior1.Attack(warrior2);
            int expectedResult = 0;
            int realResult = warrior2.HP;

            // Assert
            Assert.AreEqual(expectedResult, realResult);
        }

        [Test]
        public void Test_Attack_Else_Statment()
        {
            // Arrange            

            // Act
            this.warrior1.Attack(warrior4);
            int expectedResult = 65;
            int realResult = warrior4.HP;

            // Assert
            Assert.AreEqual(expectedResult, realResult);
        }
    }
}