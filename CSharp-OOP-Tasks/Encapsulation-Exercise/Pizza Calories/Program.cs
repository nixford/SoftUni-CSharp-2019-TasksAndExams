using System;
using System.Linq;

namespace Pizza
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                string input = Console.ReadLine();
                string[] pizzaNameArgs = input
                    .Split(' ')
                    .ToArray();

                Pizza pizza = new Pizza(pizzaNameArgs[1]);

                while ((input = Console.ReadLine()) != "END")
                {
                    string[] inputArg = input.Split(' ').ToArray();

                    string ingredient = inputArg[0];

                    if (ingredient == "Dough")
                    {
                        try
                        {
                            string flourType = inputArg[1].ToLower();
                            string bakerTechnique = inputArg[2].ToLower();
                            decimal wheight = decimal.Parse(inputArg[3]);

                            Dough dough = new Dough(wheight, flourType, bakerTechnique);

                            pizza.TotalCalories += dough.GetCallories();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            return;
                        }
                    }
                    else if (ingredient == "Topping")
                    {
                        try
                        {
                            string toppingType = inputArg[1].ToLower();
                            decimal weight = decimal.Parse(inputArg[2]);

                            Topping topping = new Topping(weight, toppingType);

                            pizza.TotalCalories += topping.GetCalloriesForTopping();

                            try
                            {
                                pizza.AddToppings(topping);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            return;
                        }
                    }
                }

                Console.WriteLine(pizza.ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }  
        }
    }
}
