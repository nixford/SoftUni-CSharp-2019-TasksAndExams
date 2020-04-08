using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warrior_s_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string text = input;

            while ((input = Console.ReadLine()) != "For Azeroth")
            {
                string[] inputLine = input.Split(' ').ToArray();
                if (inputLine[0] == "GladiatorStance")
                {
                    text = text.ToUpper();
                    Console.WriteLine(text);
                }
                else if (inputLine[0] == "DefensiveStance")
                {
                    text = text.ToLower();
                    Console.WriteLine(text);
                }
                else if (inputLine[0] == "Dispel")
                {
                    int index = int.Parse(inputLine[1]);
                    char letter = char.Parse(inputLine[2]);
                    if (index >= 0 && index < text.Length)
                    {
                        char[] temp = text.ToCharArray();
                        temp[index] = letter;
                        text = new string(temp);
                        Console.WriteLine("Success!");
                    }
                    else
                    {
                        Console.WriteLine("Dispel too weak.");
                    }                   
                }
                else if (inputLine[0] == "Target" && inputLine[1] == "Change")
                {
                    string substring = inputLine[2].ToString();
                    string secondSubstring = inputLine[3].ToString();
                    if (text.Contains(substring))
                    {
                        text = text.Replace(substring, secondSubstring);
                        Console.WriteLine(text);
                    }        
                }
                else if (inputLine[0] == "Target" && inputLine[1] == "Remove")
                {
                    string substring = inputLine[2].ToString();
                    int startIndex = text.IndexOf(substring);
                    int length = substring.Length;
                    if (startIndex >= 0 && startIndex < text.Length)
                    {
                        text = text.Remove(startIndex, length);
                        Console.WriteLine(text);
                    }                    
                }
                else
                {
                    Console.WriteLine("Command doesn't exist!");
                }                
            }
        }
    }
}
