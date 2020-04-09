using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"^%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?)\$";

            double totalMoneyPerDay = 0;

            while (input != "end of shift")
            {
                bool isMached = Regex.IsMatch(input, pattern);                
                if (isMached == true)
                {
                    Match match = Regex.Match(input, pattern);
                    string name = match.Groups["customer"].Value;
                    string product = match.Groups["product"].Value;
                    int count = int.Parse(match.Groups["count"].Value);
                    double price = double.Parse(match.Groups["price"].Value);
                    Console.WriteLine($"{name}: {product} - {count * price:f2}");
                    totalMoneyPerDay += count * price;
                }                
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {totalMoneyPerDay:f2}");            
        }
    }
}
