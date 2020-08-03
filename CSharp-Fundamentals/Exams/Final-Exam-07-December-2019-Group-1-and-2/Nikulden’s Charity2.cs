using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikulden_s_Charity2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string text = input;

            while ((input = Console.ReadLine()) != "Finish")
            {
                string[] inputLine = input.Split().ToArray();

                if (inputLine[0] == "Replace")
                {
                    string currChar = inputLine[1];
                    string newChar = inputLine[2];
                    while (text.Contains(currChar))
                    {
                        text = text.Replace(currChar, newChar);
                    }
                    Console.WriteLine(text);
                }
                else if (inputLine[0] == "Cut")
                {
                    int startIndex = int.Parse(inputLine[1]);
                    int endIndex = int.Parse(inputLine[2]);
                    if ((startIndex >= 0 && startIndex < text.Length) && 
                        (endIndex >= 0 && endIndex < text.Length))
                    {
                        text = text.Remove(startIndex, (endIndex + 1) - startIndex);
                        Console.WriteLine(text);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }                   
                }
                else if (inputLine[0] == "Make")
                {
                    if (inputLine[1] == "Upper")
                    {
                        text = text.ToUpper();
                        Console.WriteLine(text);
                    }
                    else
                    {
                        text = text.ToLower();
                        Console.WriteLine(text);
                    }
                }
                else if (inputLine[0] == "Check")
                {
                    string substring = inputLine[1];
                    if (text.Contains(substring))
                    {
                        Console.WriteLine($"Message contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {substring}");
                    }
                }
                else if (inputLine[0] == "Sum")
                {
                    int startIndex = int.Parse(inputLine[1]);
                    int endIndex = int.Parse(inputLine[2]);
                    if ((startIndex >= 0 && startIndex < text.Length) &&
                        (endIndex >= 0 && endIndex < text.Length))
                    {
                        string substring = text.Substring(startIndex, (endIndex + 1) - startIndex);
                        char[] charArr = substring.ToCharArray();
                        int sum = charArr.Select(a => (int)a).Sum();
                        Console.WriteLine(sum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }
            }
        }
    }
}
