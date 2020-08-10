//using DatabaseExtended;
//using DatabaseExtendedP02;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            database = new ExtendedDatabase();
        }

        [Test]
        public void Test_Person_Constructor()
        {
            Person person = new Person(1, "NewOne123");

            Assert.AreEqual(1, person.Id);
            Assert.AreEqual("NewOne123", person.UserName);
        }

        [Test]
        public void Test_Database_Constructure()
        {
            Person person1 = new Person(1, "NewOne1");
            Person person2 = new Person(2, "NewOne2");
            database.Add(person1);
            database.Add(person2);

            Assert.AreEqual(2, this.database.Count);
        }

        [Test]
        public void Costructor_EmptyCollection_ShouldReturnZero()
        {
            //Arrange
            database = new ExtendedDatabase();

            //Act
            int actualResult = database.Count;
            int expectedResult = 0;

            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
            //Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void AddRangeMethod_MoreThat16_ShouldReturnArgExc()
        {
            //Arrange 
            Person[] personsArr = new Person[17];

            //Act
            for (int i = 0; i < personsArr.Length; i++)
            {
                personsArr[i] = new Person(i, $"NewOne{i}");
            }

            //Assert
            Assert.Throws<ArgumentException>(() =>
            database = new ExtendedDatabase(personsArr));

        }

        [Test]
        public void AddRange_Exception_With_Empty_People()
        {
            Person[] people = new Person[17];

            Assert.Throws<ArgumentException>(() =>
                    this.database = new ExtendedDatabase(people));
        }

        [Test]
        public void AddRange_Counter_ShouldReturn16()
        {
            //Arrange
            Person[] personsArr =
                {
                    new Person(1, "NewOne1"),
                    new Person(2, "NewOne2"),
                    new Person(3, "NewOne3"),
                    new Person(4, "NewOne4"),
                    new Person(5, "NewOne5"),
                    new Person(6, "NewOne6"),
                    new Person(7, "NewOne7"),
                    new Person(8, "NewOne8"),
                    new Person(9, "NewOne9"),
                    new Person(10, "NewOne10"),
                    new Person(11, "NewOne11"),
                    new Person(12, "NewOne12"),
                    new Person(13, "NewOne13"),
                    new Person(14, "NewOne14"),
                    new Person(15, "NewOne15"),
                    new Person(16, "NewOne16"),
                    //new Person(17, "NewOne17"),
                };

            //Act
            database = new ExtendedDatabase(personsArr);
            int actualResult = database.Count;
            int expectedResult = 16;

            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
            //Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void AddMethod_MoreThat16_ShouldReturnInvOpExc()
        {
            //Arrange             
            Person person = new Person(123, "NewOne");

            //Act
            for (int i = 0; i < 16; i++)
            {
                database.Add(new Person(i, $"NewOne{i}"));
            }

            //Assert
            Assert.That(() => database.Add(person),
                Throws.InvalidOperationException.With
                .Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }        

        [Test]
        public void Add_Null_People()
        {
            Person[] people = new Person[5];

            Assert.Throws<NullReferenceException>(() =>
                    this.database = new ExtendedDatabase(people));
        }

        [Test]
        public void Add_Person_Correctly()
        {
            Person person = new Person(1, "NewOne123");
            this.database.Add(person);

            Assert.AreEqual(1, this.database.Count);
        }

        [Test]
        public void AddMethod_SameName_ShouldReturnInvOpExc()
        {
            //Arrange             
            Person person = new Person(123, "NewOne1");

            //Act
            for (int i = 0; i < 10; i++)
            {
                database.Add(new Person(i, $"NewOne{i}"));
            }

            //Assert
            Assert.That(() => database.Add(person),
                Throws.InvalidOperationException.With
                .Message.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void AddMethod_SameId_ShouldReturnInvOpExc()
        {
            //Arrange             
            Person person = new Person(1, "NewOne123");

            //Act
            for (int i = 0; i < 10; i++)
            {
                database.Add(new Person(i, $"NewOne{i}"));
            }

            //Assert
            Assert.That(() => database.Add(person),
                Throws.InvalidOperationException.With
                .Message.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void Test_Add_Person_In_Full_Database()
        {
            Person[] people = new Person[16];
            Person person = new Person(1, "NewOne123");

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Name{i}");
            }

            this.database = new ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>(() => this.database.Add(person));
        }

        [Test]
        public void AddMethod_Counter_ShouldReturn1()
        {
            //Arrange
            Person person = new Person(1, "NewOne123");

            //Act
            database.Add(person);
            int actualResult = database.Count;
            int expectedResult = 1;

            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
            //Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void Remove_Correctly()
        {
            Person person = new Person(1, "NewOne123");
            database.Add(person);

            this.database.Remove();

            Assert.AreEqual(0, this.database.Count);
        }

        [Test]
        public void RemoveMethod_RemoveOne_ShouldReturnInvOpExc()
        {
            //Arrange

            // Act            

            Assert.Throws<InvalidOperationException>(() =>
                database.Remove());
        }

        [Test]
        public void RemoveMethod_Count_ShouldReturnNull()
        {
            //Arrange
            Person person = new Person(1, "NewOne123");
            database = new ExtendedDatabase(person);
            database.Remove();

            //Act
            int actualResult = database.Count;
            int expectedResult = 0;

            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
            //Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void Find_By_Username_Correctly()
        {
            Person person = new Person(1, "NewOne123");
            database.Add(person);

            Person person1 = this.database.FindByUsername(person.UserName);

            Assert.AreEqual(person, person1);
        }

        [Test]
        public void FindByUsernameMethod_Null_ShouldReturnArgNullExc()
        {
            //Arrange            

            //Act            

            //Assert
            Assert.Throws<ArgumentNullException>(()
                => database.FindByUsername(null));
        }        

        [Test]
        public void FindByUsernameMethod_NoName_ShouldReturnInvOpExc()
        {
            //Arrange            
            Person person = new Person(1, "NewOne123");

            //Act            

            //Assert
            Assert.Throws<InvalidOperationException>(()
                => database.FindByUsername(person.UserName));
        }

        [Test]
        public void Find_By_No_Username()
        {
            Person person = new Person(1, "NewOne123");

            Assert.Throws<InvalidOperationException>(() =>
                    this.database.FindByUsername(person.UserName));
        }             

        [Test]
        public void FindByIdMethod_BelowZero_ShouldReturnArgOutOfRangeExc()
        {
            //Arrange            
            Person person = new Person(-1, "NewOne123");

            //Act            

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(()
                => database.FindById(person.Id));
        }

        [Test]
        public void FindByIdMethod_FindId_ShouldReturnInvOpExc()
        {
            //Arrange            
            Person person = new Person(10, "NewOne123");

            //Act            

            //Assert
            Assert.Throws<InvalidOperationException>(()
                => database.FindById(person.Id));
        }               

        [Test]
        public void By_Id()
        {
            Person person = new Person(1, "NewOne123");
            database.Add(person);

            Person person1 = this.database.FindById(1);

            Assert.AreEqual(person, person1);
        }

    }
}