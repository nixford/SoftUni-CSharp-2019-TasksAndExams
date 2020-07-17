using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.AnimalModels;
using WildFarm.Models.AnimalModels.BirdsModels;
using WildFarm.Models.AnimalModels.MammalModels;
using WildFarm.Models.AnimalModels.MammalModels.FelineModels;

namespace WildFarm.Factory
{
    public class AnimalFactory
    {
        public static Animal CreateAnimal(string[] animalsParams)
        {
            Animal animal = null;

            string type = animalsParams[0];
            string name = animalsParams[1];
            double weight = double.Parse(animalsParams[2]);

            switch (type)
            {
                case "Cat":
                    {
                        string livingRegion = animalsParams[3];
                        string breed = animalsParams[4];

                        animal = new Cat(name, weight, livingRegion, breed);
                    }
                    break;

                case "Tiger":
                    {
                        string livingRegion = animalsParams[3];
                        string breed = animalsParams[4];

                        animal = new Tiger(name, weight, livingRegion, breed);
                    }
                    break;

                case "Owl":
                    {
                        double wingSize = double.Parse(animalsParams[3]);

                        animal = new Owl(name, weight, wingSize);
                    }
                    break;

                case "Hen":
                    {
                        double wingSize = double.Parse(animalsParams[3]);

                        animal = new Hen(name, weight, wingSize);
                    }
                    break;

                case "Dog":
                    {
                        string livingRegion = animalsParams[3];

                        animal = new Dog(name, weight, livingRegion);
                    }
                    break;

                case "Mouse":
                    {
                        string livingRegion = animalsParams[3];

                        animal = new Mouse(name, weight, livingRegion);
                    }
                    break;

                default:
                    break;
            }

            return animal;
        }
    }
}
