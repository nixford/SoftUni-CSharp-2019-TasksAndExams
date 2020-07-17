using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.FoodModels;

namespace WildFarm.Models.AnimalModels.MammalModels.FelineModels
{
    public class Tiger : Feline
    {

        private const double WeightPerFood = 1.0;

        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
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
            return "ROAR!!!";
        }
    }
}
