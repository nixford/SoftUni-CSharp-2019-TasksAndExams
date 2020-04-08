using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Message_Translator2
{
    class Program
    {
        static void Main(string[] args)
        {
            int messageCount = int.Parse(Console.ReadLine());

            string pattern = @"!(?<command>[A-Z][a-z]{2,})!:\[(?<message>[A-Za-z]{8,})\]";

            for (int i = 0; i < messageCount; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);
                if (Regex.IsMatch(input, pattern))
                {
                    int[] numbers = match.Groups["message"].Value.Select(a => (int)a).ToArray();
                    Console.Write($"{match.Groups["command"].Value}: ");
                    Console.Write(string.Join(" ", numbers));
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"The message is invalid");
                }
            }
        }
    }
}
