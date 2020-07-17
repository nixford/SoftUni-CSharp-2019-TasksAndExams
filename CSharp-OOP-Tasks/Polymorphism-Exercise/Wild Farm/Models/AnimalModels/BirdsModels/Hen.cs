using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.FoodModels;

namespace WildFarm.Models.AnimalModels.BirdsModels
{
    public class Hen : Bird
    {
        private const double WeightPerFood = 0.35;

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
            
        }


        public override void Eat(Food food)
        {
            this.Weight += food.Quantity * WeightPerFood;
            this.FoodEaten += food.Quantity;
        }

        public override string AsqForFood()
        {
            return $"Cluck";
        }
    }
}
