using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Message_Encrypter_2222
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());

            string pattern = @"(?<surroundings>[\*|\@])(?<tag>[A-Z][a-z]{2,})\1:\s\[(?<letter1>[A-Za-z])\]\|\[(?<letter2>[A-Za-z])\]\|\[(?<letter3>[A-Za-z])\]\|$";

            for (int i = 0; i < inputNumber; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);

                if (Regex.IsMatch(input, pattern))
                {
                    string tag = match.Groups["tag"].Value;
                    int num1 = char.Parse(match.Groups["letter1"].Value);
                    int num2 = char.Parse(match.Groups["letter2"].Value);
                    int num3 = char.Parse(match.Groups["letter3"].Value);
                    Console.WriteLine($"{tag}: {num1} {num2} {num3}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
