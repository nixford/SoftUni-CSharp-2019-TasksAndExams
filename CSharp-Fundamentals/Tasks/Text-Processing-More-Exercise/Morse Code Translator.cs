using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morse_Code_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ')
                .ToArray();
            Dictionary<char, String> morseDataBse = new Dictionary<char, String>()
            {
                {'A' , ".-"}, {'B' , "-..."}, {'C' , "-.-."}, {'D' , "-.."}, {'E' , "."},
                {'F' , "..-."}, {'G' , "--."}, {'H' , "...."}, {'I' , ".."}, {'J' , ".---"},
                {'K' , "-.-"}, {'L' , ".-.."}, {'M' , "--"}, {'N' , "-."}, {'O' , "---"},
                {'P' , ".--."}, {'Q' , "--.-"}, {'R' , ".-."}, {'S' , "..."}, {'T' , "-"},
                {'U' , "..-"}, {'V' , "...-"}, {'W' , ".--"}, {'X' , "-..-"}, {'Y' , "-.--"},
                {'Z' , "--.."},                
            };
            StringBuilder textOutput = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == "|")
                {
                    textOutput.Append(" ");
                    if (morseDataBse.ContainsValue(input[i]))
                    {
                        char key = morseDataBse.FirstOrDefault(x => x.Value == input[i]).Key;
                        textOutput.Append(key);
                    }
                }
                else
                {
                    if (morseDataBse.ContainsValue(input[i]))
                    {
                        char key = morseDataBse.FirstOrDefault(x => x.Value == input[i]).Key;
                        textOutput.Append(key);
                    }
                }
            }
            Console.WriteLine(textOutput);
        }
    }
}
