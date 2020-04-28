using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"(\+359\s2\s\d{3}\s\d{4}|\+359\-2\-\d{3}\-\d{4})\b";
            string phones = Console.ReadLine();
            MatchCollection phoneMatches = Regex.Matches(phones, regex);
            string[] matchedPhones = phoneMatches
                .Cast<Match>()
                .Select(a => a.Value.Trim())
                .ToArray();

            Console.WriteLine(string.Join(", ", matchedPhones));
        }
    }
}
