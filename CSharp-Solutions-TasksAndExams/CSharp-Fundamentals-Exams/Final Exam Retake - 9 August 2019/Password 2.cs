using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Password_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());

            string pattern = @"(?<border>[\S]+)>(?<first>[0-9]{3})\|(?<second>[a-z]{3})\|(?<third>[A-Z]{3})\|(?<fourth>[^<>]{3})<\1";

            for (int i = 0; i < inputNumber; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);

                if (Regex.IsMatch(input, pattern))
                {
                    string group1 = match.Groups["first"].Value;
                    string group2 = match.Groups["second"].Value;
                    string group3 = match.Groups["third"].Value;
                    string group4 = match.Groups["fourth"].Value;
                    Console.WriteLine($"Password: {group1 + group2 + group3 + group4}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
