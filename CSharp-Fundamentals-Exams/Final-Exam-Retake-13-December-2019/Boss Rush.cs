using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Boss_Rush
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesNumber = int.Parse(Console.ReadLine());
            string pattern = @"\|(?<name>[A-Z]{4,1000})\|(\:)\#(?<title>[A-Za-z]+\s[A-Za-z]+)\#";

            for (int i = 0; i < linesNumber; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);
                if (Regex.IsMatch(input, pattern) == true)
                {
                    Console.WriteLine($"{match.Groups["name"]}, The {match.Groups["title"]}");
                    Console.WriteLine($">> Strength: {match.Groups["name"].Length}");
                    Console.WriteLine($">> Armour: {match.Groups["title"].Length}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
