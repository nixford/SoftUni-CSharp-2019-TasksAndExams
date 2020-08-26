namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        private RobotManager robotManager;
        private Robot robot;

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Constructor_ShouldBeNullValues()
        {
            RobotManager robotManager = new RobotManager(0);

            Assert.AreEqual(robotManager.Capacity, 0);            
        }

        [Test]
        public void Constructor_ShouldAcceptCorrectly()
        {
            RobotManager robotManager = new RobotManager(1);

            Assert.AreEqual(robotManager.Capacity, 1);            
        }

        [Test]
        public void Capacity_ShouldReturnException()
        {
            RobotManager robotManager;

            Assert.Throws<ArgumentException>(() =>
                    robotManager = new RobotManager(-1));
        }

        [Test]
        public void Count_ShouldBeNullValue()
        {
            RobotManager robotManager = new RobotManager(0);

            Assert.AreEqual(robotManager.Count, 0);
        }

        [Test]
        public void Count_IsIncreasingCorrectly()
        {
            robotManager = new RobotManager(5);
            robot = new Robot("Terminator", 120);

            robotManager.Add(robot);

            Assert.AreEqual(robotManager.Count, 1);
        }

        [Test]
        public void Count_IsDecreasingCorrectly()
        {
            robotManager = new RobotManager(5);
            robot = new Robot("Terminator", 120);

            robotManager.Add(robot);
            robotManager.Remove("Terminator");

            Assert.AreEqual(robotManager.Count, 0);
        }

        [Test]
        public void Add_ExceptionExistingRobot()
        {
            robotManager = new RobotManager(5);
            robot = new Robot("Terminator", 120);
            robotManager.Add(robot);
            Robot robot1 = new Robot("Terminator", 120);             

            Assert.Throws<InvalidOperationException>(() =>
            robotManager.Add(robot1));
        }

        [Test]
        public void Add_ExceptionCapacity()
        {
            robotManager = new RobotManager(1);
            robot = new Robot("Terminator", 120);
            robotManager.Add(robot);
            Robot robot1 = new Robot("Terminator101", 120);

            Assert.Throws<InvalidOperationException>(() =>
            robotManager.Add(robot1));
        }

        [Test]
        public void Add_AddCorrectly()
        {
            robotManager = new RobotManager(5);
            robot = new Robot("Terminator", 120);
            robotManager.Add(robot);

            Robot robot1 = new Robot("Terminator101", 120);
            robotManager.Add(robot1);

            Assert.AreEqual(robotManager.Count, 2);
        }

        [Test]
        public void Remove_Exception()
        {
            robotManager = new RobotManager(5);
            robot = new Robot("Terminator", 120);
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
             robotManager.Remove("Terminator101"));
        }

        [Test]
        public void Remove_Correctly()
        {
            robotManager = new RobotManager(5);
            robot = new Robot("Terminator", 120);
            robotManager.Add(robot);
            robotManager.Remove("Terminator");

            Assert.AreEqual(robotManager.Count, 0);
        }

        [Test]
        public void Work_NoRobotException()
        {
            robotManager = new RobotManager(5);
            robot = new Robot("Terminator", 120);
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
             robotManager.Work("Terminator101", "Flying", 10));
        }

        [Test]
        public void Work_NoBatteryException()
        {
            robotManager = new RobotManager(5);
            robot = new Robot("Terminator", 120);
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
             robotManager.Work("Terminator", "Flying", 150));
        }

        [Test]
        public void Work_BattaryCorrectDecreasing()
        {
            robotManager = new RobotManager(5);
            robot = new Robot("Terminator", 120);
            robotManager.Add(robot);
            robotManager.Work("Terminator", "Flying", 100);

            Assert.AreEqual(robot.Battery, 20);
        }

        [Test]
        public void Charge_NoRobotException()
        {
            robotManager = new RobotManager(5);
            robot = new Robot("Terminator", 120);
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
             robotManager.Charge("Terminator101"));
        }

        [Test]
        public void Charge_CorrectCharging()
        {
            robotManager = new RobotManager(5);
            robot = new Robot("Terminator", 120);
            robotManager.Add(robot);

            robotManager.Work("Terminator", "Flying", 100);
            robotManager.Charge("Terminator");

            Assert.AreEqual(robot.Battery, 120);
        }
    }
}
