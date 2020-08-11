//using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("Make", "Model", 10, 100);            
        }

        [Test]
        public void Test_Car_Constructor()
        {            
            Assert.AreEqual("Make", car.Make);
            Assert.AreEqual("Model", car.Model);
            Assert.AreEqual(10, car.FuelConsumption);
            Assert.AreEqual(100, car.FuelCapacity);
        }

        [Test]
        public void Test_Make()
        {
            Assert.Throws<ArgumentException>(() 
                => car = new Car(null, "Model", 10, 100));
        }

        [Test]
        public void Test_Model()
        {
            Assert.Throws<ArgumentException>(()
                => car = new Car("Make", null, 10, 100));
        }

        [Test]
        public void Test_FuelConsumption()
        {
            Assert.Throws<ArgumentException>(()
                => car = new Car("Make", "Model", 0, 100));
        }

        [Test]
        public void Test_FuelCapacity()
        {
            Assert.Throws<ArgumentException>(()
                => car = new Car("Make", "Model", 10, 0));
        }

        [Test]
        public void Test_FuelAmount()
        {
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        public void Test_Refueling_Correctly()
        {
            this.car.Refuel(15);
            int expectedFuel = 15;

            Assert.AreEqual(expectedFuel, this.car.FuelAmount);
        }

        [Test]
        public void Test_ZeroOrNegative_Refuel()
        {
            Assert.Throws<ArgumentException>(() 
                => car.Refuel(0));
        }

        [Test]
        public void Test_OverflowFueling_Refuel()
        {
            // Arrange
            double expectedResults = 100;            

            // Act
            car.Refuel(120);
            double realResult = car.FuelAmount;

            // Assert
            Assert.AreEqual(expectedResults, realResult);
        }

        [Test]
        public void TestDrivingCorrectly()
        {
            this.car.Refuel(10);
            this.car.Drive(50);
            double expectedFuel = 5;

            Assert.AreEqual(expectedFuel, this.car.FuelAmount);
        }

        [Test]
        public void Test_Drive()
        {
            Assert.Throws<InvalidOperationException>(() 
                => car.Drive(5000));
        }
    }
}