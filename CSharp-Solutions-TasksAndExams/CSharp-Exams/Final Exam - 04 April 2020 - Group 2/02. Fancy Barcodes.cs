using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());

            string pattern = @"(?<surroundingsFront>[\@][\#]+)(?<barcode>[A-Z][A-Za-z0-9]{4,}[A-Z])(?<surroundingsBack>[\@][\#]+)";
            List<char> productGroup = new List<char>();

            for (int i = 0; i < inputNumber; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);

                if (Regex.IsMatch(input, pattern))
                {
                    string barcode = match.Groups["barcode"].Value;
                    bool thereIsDigit = false;

                    for (int j = 0; j < barcode.Length; j++)
                    {
                        if (Char.IsNumber(barcode[j]))
                        {                            
                            productGroup.Add(barcode[j]);
                            thereIsDigit = true;
                        }
                    }

                    if (thereIsDigit == true)
                    {
                        Console.WriteLine($"Product group: {string.Join("", productGroup)}");
                        productGroup = new List<char>();
                    }
                    else
                    {
                        Console.WriteLine($"Product group: 00");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }            
        }
    }
}
