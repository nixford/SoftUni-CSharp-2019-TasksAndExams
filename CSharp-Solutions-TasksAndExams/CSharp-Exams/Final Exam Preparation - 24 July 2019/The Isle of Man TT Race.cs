using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace The_Isle_of_Man_TT_Race2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            string pattern = @"^(?<surrounding>[\#|\$|\%|\*|\&])(?<racerName>[A-Za-z]+)\1=(?<lengthCode>[0-9]+)!!(?<encriptedCode>.*)$";

            while (true)
            {
                input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);
                if (Regex.IsMatch(input, pattern))
                {
                    string message = match.ToString();
                    int legthCode = int.Parse(match.Groups["lengthCode"].Value);
                    string encriptedCode = match.Groups["encriptedCode"].Value;
                    string racerName = match.Groups["racerName"].Value;
                    List<char> decriptedLetters = new List<char>();

                    if (legthCode == encriptedCode.Length)
                    {
                        for (int i = 0; i < encriptedCode.Length; i++)
                        {
                            decriptedLetters.Add((char)(encriptedCode[i] + legthCode));
                        }
                        Console.WriteLine($"Coordinates found! {racerName} -> {string.Join("", decriptedLetters)}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }
            }
        }
    }
}
