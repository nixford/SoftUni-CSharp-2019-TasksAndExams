using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.AnimalModels.MammalModels.FelineModels
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, 
            double weight,             
            string livingRegion,
            string breed) 
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public override string ToString()
        {
            return base.ToString() +
                $"[{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
        public string Breed { get; private set; }
    }
}
