using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<Engine> engines = new HashSet<Engine>();
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] engineArg = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Engine engine = null;

                string model = engineArg[0];
                int power = int.Parse(engineArg[1]);

                if (engineArg.Length == 4)
                {
                    int displacement = int.Parse(engineArg[2]);
                    string efficiency = engineArg[3];
                    engine = new Engine(model, power, displacement, efficiency);
                }
                else if (engineArg.Length == 3)
                {
                    int displacement;
                    bool isDisplacement = int.TryParse(engineArg[2], out displacement);

                    if (isDisplacement)
                    {
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        engine = new Engine(model, power, engineArg[2]);
                    }
                }
                else if (engineArg.Length == 2)
                {
                    engine = new Engine(model, power);
                }
                if (engine != null)
                {
                    engines.Add(engine);
                }                
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] carArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Car car = null;

                string model = carArgs[0];
                Engine engine = engines.First(e => e.Model == carArgs[1]);

                if (carArgs.Length == 2)
                {
                    car = new Car(model, engine);
                }
                else if (carArgs.Length == 3)
                {
                    int weight;
                    bool isWeigt = int.TryParse(carArgs[2], out weight);

                    if (isWeigt)
                    {
                        car = new Car(model, engine, weight);
                    }
                    else
                    {
                        string color = carArgs[2];
                        car = new Car(model, engine, color);
                    }
                } 
                else if (carArgs.Length == 4)
                {
                    double weight = double.Parse(carArgs[2]);
                    string color = carArgs[3];
                    car = new Car(model, engine, weight, color);
                }

                if (car != null)
                {
                    cars.Add(car);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
