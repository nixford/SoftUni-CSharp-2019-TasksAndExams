using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.FoodModels;

namespace WildFarm.Models.AnimalModels.BirdsModels
{
    public class Owl : Bird
    {
        private const double WeightPerFood = 0.25;

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {

        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name != nameof(Meat))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.Weight += food.Quantity * WeightPerFood;
            this.FoodEaten += food.Quantity;
        }

        public override string AsqForFood()
        {
            return "Hoot Hoot";
        }
    }
}
