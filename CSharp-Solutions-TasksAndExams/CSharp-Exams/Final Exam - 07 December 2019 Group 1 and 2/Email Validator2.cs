using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Validator2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string text = input;

            while ((input = Console.ReadLine()) != "Complete")
            {
                string[] inputLine = input.Split(' ').ToArray();

                if (inputLine[0] == "Make" && inputLine[1] == "Upper")
                {
                    text = text.ToUpper();
                    Console.WriteLine(text);
                }
                else if (inputLine[0] == "Make" && inputLine[1] == "Lower")
                {
                    text = text.ToLower();
                    Console.WriteLine(text);
                }
                else if (inputLine[0] == "GetDomain")
                {
                    int count = int.Parse(inputLine[1]);
                    string substring = text.Substring(text.Length - count);
                    Console.WriteLine(substring);
                }
                else if (inputLine[0] == "GetUsername")
                {
                    if (text.Contains('@'))
                    {
                        int index = text.IndexOf('@');
                        string substring = text.Substring(0, index);
                        Console.WriteLine(substring);
                    }
                    else
                    {
                        Console.WriteLine($"The email {text} doesn't contain the @ symbol.");
                    }
                }
                else if (inputLine[0] == "Replace")
                {
                    char letter = char.Parse(inputLine[1]);
                    while (text.Contains(letter))
                    {
                        text = text.Replace(letter, '-');
                    }
                    Console.WriteLine(text);
                }
                else if (inputLine[0] == "Encrypt")
                {
                    for (int i = 0; i < text.Length; i++)
                    {
                        Console.Write((int)text[i] + " ");
                    }
                }
            }
        }
    }
}
