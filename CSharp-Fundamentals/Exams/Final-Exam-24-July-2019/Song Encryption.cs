using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Song_Encryption2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            string pattern = @"^(?<artist>[A-Z][a-z|\'|\s]+):(?<song>[A-Z|\s]+)$";

            while ((input = Console.ReadLine()) != "end")
            {
                Match match = Regex.Match(input, pattern);
                if (Regex.IsMatch(input, pattern))
                {
                    string artist = match.Groups["artist"].Value;
                    string song = match.Groups["song"].Value;
                    int key = artist.Length;
                    string currInput = match.ToString();
                    List<char> decritedInput = new List<char>();

                    for (int i = 0; i < currInput.Length; i++)
                    {
                        if (currInput[i] == ' ' || currInput[i] == '\'')
                        {
                            decritedInput.Add(currInput[i]);
                        }
                        else if (currInput[i] == ':')
                        {
                            decritedInput.Add('@');
                        }
                        else
                        {
                            if (Char.IsLower(currInput[i]))
                            {
                                if (key + currInput[i] <= 122)
                                {
                                    decritedInput.Add((char)(key + currInput[i]));
                                }
                                else
                                {
                                    decritedInput.Add((char)(((key + currInput[i]) - 123) + 97));
                                }
                            }
                            else // if char is Upper case
                            {
                                if (key + currInput[i] <= 90)
                                {
                                    decritedInput.Add((char)(key + currInput[i]));
                                }
                                else
                                {
                                    decritedInput.Add((char)(((key + currInput[i]) - 91) + 65));
                                }
                            }
                        }
                    }
                    Console.WriteLine($"Successful encryption: {string.Join("", decritedInput)}");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
