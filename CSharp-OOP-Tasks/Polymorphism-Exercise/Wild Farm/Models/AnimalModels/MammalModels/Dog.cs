using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.FoodModels;

namespace WildFarm.Models.AnimalModels.MammalModels
{
    public class Dog : Mammal
    {
        private const double WeightPerFood = 0.40;
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
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
            return "Woof!";
        }

        public override string ToString()
        {
            return base.ToString() + $"[{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
