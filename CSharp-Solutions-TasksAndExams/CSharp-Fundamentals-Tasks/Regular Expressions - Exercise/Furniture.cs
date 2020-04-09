using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(\w+)<<([-+]?[0-9]*\.?[0-9]+)!(\d+)";
            Regex regex = new Regex(pattern);                       

            string input = Console.ReadLine();
            double totalSum = 0;

            Console.WriteLine("Bought furniture:");
            while (input != "Purchase")
            {
                Match match = regex.Match(input);
                if (match.Success == true)
                {
                    string furnitureType = match.Groups[1].Value;                   
                    Console.WriteLine(furnitureType);
                    double price = double.Parse(match.Groups[2].Value);
                    int quantity = int.Parse(match.Groups[3].Value);
                    totalSum += price * quantity;
                }     
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total money spend: {totalSum:f2}");
        }
    }
}
