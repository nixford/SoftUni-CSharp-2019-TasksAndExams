using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Santa_s_Secret_Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            byte key = byte.Parse(Console.ReadLine());
            string input = string.Empty;
            StringBuilder decritedText = new StringBuilder();
            List<string> names = new List<string>();

            string patternFirst = @"\@(?<name>[A-Z][a-z]+)([^\@|\-\!\:\>]+)(\!G\!)";            

            while (true)
            {
                input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                // Decription
                for (int i = 0; i < input.Length; i++)
                {
                    decritedText.Append((char)(input[i] - key));
                }
                Match nameMach = Regex.Match(decritedText.ToString(), patternFirst);                
                if (Regex.IsMatch(decritedText.ToString(), patternFirst))
                {
                    names.Add(nameMach.Groups["name"].Value);
                }
                decritedText = new StringBuilder();
            }
            Console.WriteLine(string.Join("\n", names));
        }
    }
}
