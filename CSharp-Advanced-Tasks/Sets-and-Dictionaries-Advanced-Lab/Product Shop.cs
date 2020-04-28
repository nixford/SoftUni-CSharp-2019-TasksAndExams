using System;
using System.Collections.Generic;
using System.Linq;

namespace Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Dictionary<string, Dictionary<string, double>> dataBase = 
                new Dictionary<string, Dictionary<string, double>>(); 

            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] commandLine = input
                    .Split(new string[] { ", " }, 
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string shop = commandLine[0];
                string product = commandLine[1];
                bool priceTry = double.TryParse(commandLine[2], out double result);
                double price = result;

                if (!dataBase.ContainsKey(shop))
                {
                    dataBase.Add(shop, new Dictionary<string, double>());
                    if (!dataBase[shop].ContainsKey(product))
                    {
                        dataBase[shop].Add(product, price);
                    }
                    else
                    {
                        dataBase[shop][product] = price;
                    }
                }
                else
                {
                    if (!dataBase[shop].ContainsKey(product))
                    {
                        dataBase[shop].Add(product, price);
                    }
                    else
                    {
                        dataBase[shop][product] = price;
                    }
                }
            }
            foreach (var kvp in dataBase.OrderBy(k => k.Key))
            {
                Console.WriteLine($"{kvp.Key}->");
                foreach (var product in kvp.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
