using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, double> productAndPriceDict = new Dictionary<string, double>();
            Dictionary<string, int> productAndQuantity = new Dictionary<string, int>();

            while (input != "buy")
            {
                string[] inpupLine = input.Split(' ').ToArray();
                string product = inpupLine[0];
                double price = double.Parse(inpupLine[1]);
                int quantity = int.Parse(inpupLine[2]);

                if (!productAndPriceDict.ContainsKey(product) && !productAndQuantity.ContainsKey(product))
                {
                    productAndPriceDict.Add(product, price);
                    productAndQuantity.Add(product, quantity);
                }
                else
                {
                    productAndPriceDict[product] = price;
                    productAndQuantity[product] = productAndQuantity[product] + quantity;
                }
                input = Console.ReadLine();
            }
            List<string> products = new List<string>();
            foreach (var price in productAndPriceDict)
            {
                foreach (var quantity in productAndQuantity)
                {
                    if (productAndQuantity.ContainsKey(price.Key) && !products.Contains(quantity.Key))
                    {
                        Console.WriteLine($"{price.Key} -> {price.Value * quantity.Value:f2}");                        
                        products.Add(price.Key);
                        break;
                    }
                }                
            }
        }
    }
}
