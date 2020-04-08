using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Message_Decrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesNumber = int.Parse(Console.ReadLine());

            string pattern = @"^(?<surrounding>[\$|\%])(?<tag>[A-Z][a-z]{2,})\1:\s\[(?<first>[\d]+)\]\|\[(?<second>[\d]+)\]\|\[(?<third>[\d]+)\]\|$";

            for (int i = 0; i < linesNumber; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);
                if (Regex.IsMatch(input, pattern))
                {
                    int firstNum = int.Parse(match.Groups["first"].Value);
                    int secondNum = int.Parse(match.Groups["second"].Value);
                    int thirdNum = int.Parse(match.Groups["third"].Value);
                    char firstLetter = (char)(firstNum);
                    char secondLetter = (char)(secondNum);
                    char thirdLetter = (char)(thirdNum);
                    Console.WriteLine($"{match.Groups["tag"].Value}: " + firstLetter + secondLetter + thirdLetter);                    
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
