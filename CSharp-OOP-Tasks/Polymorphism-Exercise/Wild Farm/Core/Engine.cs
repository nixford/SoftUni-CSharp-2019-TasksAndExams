using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Factory;
using WildFarm.IO;
using WildFarm.Models.AnimalModels;
using WildFarm.Models.AnimalModels.MammalModels.FelineModels;
using WildFarm.Models.FoodModels;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        List<Animal> animals = new List<Animal>();

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader; // FileReader();
            this.writer = writer;            
        }

        public void Run()
        {
            List<Animal> animals = new List<Animal>();

            string line = this.reader.CustomReadLine();

            while (line != "End")
            {
                string[] animalsParams = line.Split();
                string[] foodParams = Console.ReadLine().Split();

                Animal animal = AnimalFactory.CreateAnimal(animalsParams);
                Food food = FoodFactory.CreateFood(foodParams);

                this.writer.CustomWriteLine(animal.AsqForFood());

                try
                {
                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    this.writer.CustomWriteLine(ex.Message);
                }

                animals.Add(animal);

                line = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                this.writer.CustomWriteLine(animal);
            }
        }   
    }
}
