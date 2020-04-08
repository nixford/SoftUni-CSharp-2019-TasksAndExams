using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Manipulator___Group_1___2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string text = input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputLine = input.Split(' ').ToArray();

                if (inputLine[0] == "Translate")
                {
                    string letter = inputLine[1];
                    string replacement = inputLine[2];
                    while (text.Contains(letter))
                    {
                        text = text.Replace(letter, replacement);
                    }
                    Console.WriteLine(text);
                }
                else if (inputLine[0] == "Includes")
                {
                    string substring = inputLine[1];
                    if (text.Contains(substring))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (inputLine[0] == "Start")
                {
                    string substring = inputLine[1];
                    if (text.StartsWith(substring))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (inputLine[0] == "Lowercase")
                {
                    text = text.ToLower();
                    Console.WriteLine(text);
                }
                else if (inputLine[0] == "FindIndex")
                {
                    char letter = char.Parse(inputLine[1]);
                    int lastIndex = text.LastIndexOf(letter);
                    Console.WriteLine(lastIndex);
                }
                else if (inputLine[0] == "Remove")
                {
                    int startIndex = int.Parse(inputLine[1]);
                    int count = int.Parse(inputLine[2]);
                    text = text.Remove(startIndex, count);
                    Console.WriteLine(text);
                }
            }
        }
    }
}
