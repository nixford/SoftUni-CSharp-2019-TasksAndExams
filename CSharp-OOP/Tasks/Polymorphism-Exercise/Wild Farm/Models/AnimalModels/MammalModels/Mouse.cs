using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.FoodModels;

namespace WildFarm.Models.AnimalModels.MammalModels
{
    public class Mouse : Mammal
    {
        public const double WeightPerFood = 0.10;
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name != nameof(Vegetable) && food.GetType().Name != nameof(Fruit))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.Weight += food.Quantity * WeightPerFood;
            this.FoodEaten += food.Quantity;
        }
        public override string AsqForFood()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return base.ToString() + $"[{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
