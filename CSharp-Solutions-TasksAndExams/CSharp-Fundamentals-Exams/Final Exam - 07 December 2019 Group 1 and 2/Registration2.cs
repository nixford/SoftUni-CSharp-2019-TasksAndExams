using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Registration2
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());

            string pattern = @"(?<surr1>U\$)(?<username>[A-Z][a-z]{2,})\1(?<surr2>P\@\$)(?<password>[A-Za-z]{5,}[0-9]+)\3";
            int successfulRegistrationsCount = 0;

            for (int i = 0; i < inputNumber; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);

                if (Regex.IsMatch(input, pattern))
                {
                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {match.Groups["username"].Value}, Password: {match.Groups["password"].Value}");
                    successfulRegistrationsCount++;
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }

            }
            Console.WriteLine($"Successful registrations: {successfulRegistrationsCount}");
        }
    }
}
