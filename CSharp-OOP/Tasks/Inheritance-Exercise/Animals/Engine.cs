using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Animals
{
    public class Engine
    {
        private const string END_OF_INPUT_COMMAND = "Beast!";

        private readonly List<Animal> animals;
        public Engine()
        {
            this.animals = new List<Animal>();
        }

        public void Run()
        {


            string type = string.Empty;

            while ((type = Console.ReadLine()) != END_OF_INPUT_COMMAND)
            {
                string[] animalArgs = Console.ReadLine()
                    .Split(' ')
                    .ToArray();
                Animal animal = GetAnimal(type, animalArgs);

                this.animals.Add(animal);
            }

            PrintOutput();
        }

        private void PrintOutput()
        {
            foreach (Animal animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }

        private Animal GetAnimal(string type, string[] animalArgs)
        {
            Animal animal = null;

            string name = animalArgs[0];
            int age = int.Parse(animalArgs[1]);
            string gender = GetGender(animalArgs);

            if (type == "Dog")
            {
                animal = new Dog(name, age, gender);
            }
            else if (type == "Cat")
            {
                animal = new Cat(name, age, gender);
            }
            else if (type == "Frog")
            {
                animal = new Frog(name, age, gender);
            }
            else if (type == "Kitten")
            {
                animal = new Kitten(name, age);
            }
            else if (type == "Tomcat")
            {
                animal = new Tomcat(name, age);
            }
            else
            {
                throw new ArgumentException("Invalid input!");
            }
            return animal;
        }   
        private string GetGender(string[] animalArgs)
        {
            string gender = null;
            if (animalArgs.Length >= 3)
            {
                gender = animalArgs[2];
            }

            return gender;
        }
    }
}
