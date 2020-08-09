//using DatabaseP01;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Costructor_EmptyCollection_ShouldReturnZero()
        {
            //Arrange
            Database database = new Database();

            //Act
            int actualResult = database.Count;
            int expectedResult = 0;


            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
            //Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void Costructor_WithTwoNumbers_ShouldReturnTwo()
        {
            //Arrange
            Database database = new Database(1, 2);

            //Act
            int actualResult = database.Count;
            int expectedResult = 2;


            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
            //Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void Costructor_WithTwoNumbers_ShouldBeAddedCorrectly()
        {
            //Arrange
            Database database = new Database(1, 2);

            //Act
            int[] actualResult = database.Fetch();
            int[] expectedResult = { 1, 2 };


            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
            //Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void Costructor_WithMoreThan16_ShouldThrowInvOpEx()
        {
            //Arrange
            int[] numbers = new int[17];
           
            //Assert
            Assert.Throws<InvalidOperationException>(() => 
                new Database(numbers));           
        }

        [Test]
        public void AddMethod_WithMoreThan16_ShouldThrowInvOpEx()
        {
            //Arrange
            int[] numbers = new int[16];
            Database database = new Database(numbers);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
                database.Add(0));
        }


        [Test]
        public void AddMethod_AddOneNumber_ShouldIncreaseCounter()
        {
            //Arrange            
            Database database = new Database();

            // Act
            database.Add(1);
            int actualResult = database.Count;
            int expectedResult = 1;

            //Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void AddMethod_AddOTwoNumber_ShouldBeAddedCorrectly()
        {
            //Arrange            
            Database database = new Database();

            // Act
            database.Add(0);
            database.Add(1);
            int[] actualResult = database.Fetch();
            int[] expectedResult = { 0, 1 };

            //Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void RemoveMethod_RemoveOne_ShouldBeNull()
        {
            //Arrange
            int[] numbers = new int[0];
            Database database = new Database(numbers);

            // Act            

            //Assert
            //Assert.That(() => database.Remove(),
            //Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));

            Assert.Throws<InvalidOperationException>(() =>
                database.Remove());
        }

        [Test]
        public void RemoveMethod_CounterCheck_ShouldBeNull()
        {
            //Arrange            
            Database database = new Database();
            int[] numbers = new int[1];

            // Act
            database = new Database(numbers);
            database.Remove();
            int actualResult = database.Count;
            int expectedResult = 0;

            //Assert
            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}