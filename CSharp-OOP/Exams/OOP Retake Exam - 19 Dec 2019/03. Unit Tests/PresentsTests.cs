namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Constructor_ShouldBeNullValues()
        {
            bag = new Bag();
            Assert.AreEqual(bag.GetPresents().Count, 0);
        }

        [Test]
        public void Create_PresentIsNullException()
        {
            bag = new Bag();
            Assert.Throws<ArgumentNullException>(() =>
                   bag.Create(null));
        }

        [Test]
        public void Create_AlreadyExistException()
        {
            bag = new Bag();
            Present present1 = new Present("Truck", 10);
            Present present2 = new Present("Ball", 15);
            bag.Create(present1);
            bag.Create(present2);

            Assert.Throws<InvalidOperationException>(() =>
                   bag.Create(present1));
        }

        [Test]
        public void Create_CorrectlyNewPresent()
        {
            bag = new Bag();

            Present present1 = new Present("Truck", 10);
            
            bag.Create(present1);
            
            Assert.AreEqual(bag.GetPresents().Count, 1);
        }

        [Test]
        public void Create_ReturnCorrectlyString()
        {
            bag = new Bag();

            Present present1 = new Present("Truck", 10);
            
            string actualResult = bag.Create(present1);
            string expectedResult = $"Successfully added present {present1.Name}.";

            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void Remove_ReturnCorrectly()
        {
            bag = new Bag();

            Present present1 = new Present("Truck", 10);
            bag.Create(present1);
            

            Assert.AreEqual(bag.Remove(present1), true);
        }

        [Test]
        public void GetPresentWithLeastMagic_CorrectResult()
        {
            bag = new Bag();

            Present present1 = new Present("Truck", 10);
            Present present2 = new Present("Ball", 15);
            bag.Create(present1);
            bag.Create(present2);

            Present actualResult = bag.GetPresentWithLeastMagic();
            Present expectedResult = present1;

            Assert.AreEqual(actualResult.Magic, expectedResult.Magic);
        }

        [Test]
        public void GetPresent_ShouldReturnNull()
        {
            bag = new Bag();

            Assert.AreEqual(bag.GetPresent("Truck"), null);
        }

        [Test]
        public void GetPresent_ShouldReturnValue()
        {
            bag = new Bag();

            Present present1 = new Present("Truck", 10);
            Present present2 = new Present("Ball", 15);
            bag.Create(present1);
            bag.Create(present2);

            Assert.AreEqual(bag.GetPresent("Truck"), present1);
        }

        [Test]
        public void GetPresents_ShouldReturnCount()
        {
            bag = new Bag();

            Present present1 = new Present("Truck", 10);
            Present present2 = new Present("Ball", 15);
            bag.Create(present1);
            bag.Create(present2);

            Assert.AreEqual(bag.GetPresents().Count, 2);
        }
    }
}
