namespace Computers.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    public class ComputerTests
    {        

        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void Constructor_EmptyValues()
        {
            Computer computer = new Computer("NewOne");
            
            Assert.AreEqual(computer.Parts.Count, 0);
        }

        [Test]
        public void Constructor_CorrectEnteringValues()
        {
            Computer computer = new Computer("NewOne");            

            Assert.AreEqual(computer.Name, "NewOne");
        }

        [Test]
        public void NameProperty_NullException()
        {
            Computer computer;

            Assert.Throws<ArgumentNullException>(() => computer = new Computer(null));
        }

        [Test]
        public void IReadOnlyCollection_Part_ForbiddenChanges()
        {
            Part part = new Part("CPU", 500);            
            Computer computer = new Computer("NewOne");
            computer.AddPart(part);           

            computer.RemovePart(part);

            Assert.AreEqual(part.Name, "CPU");
        }

        [Test]
        public void TotalPrice_CorrectSum()
        {
            Part part1 = new Part("CPU", 500);
            Part part2 = new Part("RAM", 300);
            Computer computer = new Computer("NewOne");
            computer.AddPart(part1);
            computer.AddPart(part2);

            Assert.AreEqual(computer.TotalPrice, 800);
        }

        [Test]
        public void AddPart_NullException()
        {           
            Computer computer = new Computer("NewOne");                       

            Assert.Throws<InvalidOperationException>
                (() => computer.AddPart(null));
        }

        [Test]
        public void AddPart_CorrectCount()
        {
            Computer computer = new Computer("NewOne");
            Part part1 = new Part("CPU", 500);
            Part part2 = new Part("RAM", 300);
            computer.AddPart(part1);
            computer.AddPart(part2);

            Assert.AreEqual(computer.Parts.Count, 2);
        }

        [Test]
        public void RemovePart_CorrectCount()
        {
            Computer computer = new Computer("NewOne");
            Part part1 = new Part("CPU", 500);
            Part part2 = new Part("RAM", 300);
            computer.AddPart(part1);
            computer.AddPart(part2);

            computer.RemovePart(part2);

            Assert.AreEqual(computer.Parts.Count, 1);
        }

        [Test]
        public void GetPart_CorrectResult()
        {
            Computer computer = new Computer("NewOne");
            Part part1 = new Part("CPU", 500);
            Part part2 = new Part("RAM", 300);
            computer.AddPart(part1);
            computer.AddPart(part2);

            Part part3 = computer.GetPart("CPU");

            Assert.AreEqual(part3.Name, part1.Name);
        }
    }
}