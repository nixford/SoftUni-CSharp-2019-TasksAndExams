using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.FoodModels;

namespace WildFarm.Models.AnimalModels
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }
        public string Name { get; protected set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public abstract string AsqForFood();

        public abstract void Eat(Food food);

        public override string ToString()
        {
            return $"{this.GetType().Name} ";
        }
    }
}
