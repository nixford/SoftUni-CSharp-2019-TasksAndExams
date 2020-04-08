using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Manipulator___Group_2___2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string text = input;

            while ((input = Console.ReadLine()) != "Done")
            {
                string[] inputLine = input.Split(' ').ToArray();

                if (inputLine[0] == "Change")
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
                else if (inputLine[0] == "End")
                {
                    string substring = inputLine[1];
                    if (text.EndsWith(substring))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (inputLine[0] == "Uppercase")
                {
                    text = text.ToUpper();
                    Console.WriteLine(text);
                }
                else if (inputLine[0] == "FindIndex")
                {
                    char letter = char.Parse(inputLine[1]);
                    int firstIndex = text.IndexOf(letter);
                    Console.WriteLine(firstIndex);
                }
                else if (inputLine[0] == "Cut")
                {
                    int startIndex = int.Parse(inputLine[1]);
                    int length = int.Parse(inputLine[2]);

                    text = text.Substring(startIndex, length);
                    Console.WriteLine(text);
                }
            }
        }
    }
}
