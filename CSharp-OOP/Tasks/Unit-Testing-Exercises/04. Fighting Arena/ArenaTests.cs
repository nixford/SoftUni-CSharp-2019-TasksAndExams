//using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }
       
        [Test]
        public void Test_ConstructureArena()
        {
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void Test_ForAlreadyEnrolled()
        {
            // Arrange
            Warrior warrior1 = new Warrior("Doro", 10, 100);
            Warrior warrior2 = new Warrior("Doro", 10, 100);

            // Act
            arena.Enroll(warrior1);

            // Assert
            Assert.Throws<InvalidOperationException>
                (() => arena.Enroll(warrior2));
        }

        [Test]
        public void Test_Enroll()
        {
            // Arrange
            Warrior warrior1 = new Warrior("Doro", 10, 100);            

            // Act
            arena.Enroll(warrior1);

            // Assert
            Assert.That(arena.Count, Is.EqualTo(1));
        }

        [Test]
        public void Test_Fight_Player_One_Exception()
        {
            Warrior warrior1 = new Warrior("Doro", 10, 100);
            Warrior warrior2 = new Warrior("Boro", 10, 100);

            this.arena.Enroll(warrior1);
            this.arena.Enroll(warrior2);

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Joro", "Boro"));
        }

        [Test]
        public void Test_Fight_Player_Two_Exception()
        {
            Warrior warrior1 = new Warrior("Doro", 10, 100);
            Warrior warrior2 = new Warrior("Boro", 10, 100);

            this.arena.Enroll(warrior1);
            this.arena.Enroll(warrior2);

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Doro", "Joro"));
        }

        [Test]
        public void Test_Fight_Method()
        {
            Warrior warrior1 = new Warrior("Doro", 20, 100);
            Warrior warrior2 = new Warrior("Boro", 10, 50);

            this.arena.Enroll(warrior1);
            this.arena.Enroll(warrior2);

            this.arena.Fight("Doro", "Boro");

            Assert.AreEqual(90, warrior1.HP);
            Assert.AreEqual(30, warrior2.HP);
        }

    }
}
