using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Username_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string text = input;

            while ((input = Console.ReadLine()) != "Sign up")
            {
                string[] inputLine = input.Split(' ').ToArray();

                if (inputLine[0] == "Case")
                {
                    if (inputLine[1] == "lower")
                    {
                        text = text.ToLower();
                        Console.WriteLine(text);
                    }
                    else
	                {
                        text = text.ToUpper();
                        Console.WriteLine(text);
                    }

                }
                else if (inputLine[0] == "Reverse")
                {
                    int startIndex = int.Parse(inputLine[1]);
                    int endIndex = int.Parse(inputLine[2]);
                    if ((startIndex >= 0 && startIndex < text.Length) && 
                        (endIndex >= 0 && endIndex < text.Length))
                    {
                        string substring = text.Substring(startIndex, endIndex - startIndex + 1);
                        char[] revercedArr = substring.ToCharArray();
                        Array.Reverse(revercedArr);
                        Console.WriteLine(revercedArr);
                    }

                }
                else if (inputLine[0] == "Cut")
                {
                    string substring = inputLine[1];
                    if (text.Contains(substring))
                    {
                        text = text.Replace(substring, string.Empty);
                        Console.WriteLine(text);
                    }
                    else
                    {
                        Console.WriteLine($"The word {text} doesn't contain {substring}.");
                    }
                }
                else if (inputLine[0] == "Replace")
                {
                    string letter = inputLine[1];
                    while (text.Contains(letter))
                    {
                        text = text.Replace(letter, "*");
                    }
                    Console.WriteLine(text);
                }
                else if (inputLine[0] == "Check")
                {
                    string letter = inputLine[1];
                    if (text.Contains(letter))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine($"Your username must contain {letter}.");
                    }
                }
            }
        }
    }
}
