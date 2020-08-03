using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.AnimalModels;

namespace WildFarm.IO
{
    public class ConsoleWriter : IWriter
    {
        public void CustomWrite(string text)
        {
            Console.Write(text);
        }

        public void CustomWriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public void CustomWriteLine(Animal animal)
        {
            Console.WriteLine(animal);
        }
    }
}
