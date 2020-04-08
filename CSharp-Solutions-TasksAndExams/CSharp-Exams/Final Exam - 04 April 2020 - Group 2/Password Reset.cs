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
            List<char> temp = new List<char>();

            while ((input = Console.ReadLine()) != "Done")
            {
                string[] inputLine = input.Split(' ').ToArray();

                if (inputLine[0] == "TakeOdd")
                {                    
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (i % 2 != 0 && i > 0)
                        {
                            temp.Add(text[i]);
                        }
                    }
                    text = string.Join("", temp);
                    Console.WriteLine(text);
                }
                else if (inputLine[0] == "Cut")
                {
                    int index = int.Parse(inputLine[1]);
                    int length = int.Parse(inputLine[2]);
                    text = text.Remove(index, length);
                    Console.WriteLine(text);
                }
                else if (inputLine[0] == "Substitute")
                {
                    string substring = inputLine[1];
                    string newstring = inputLine[2];

                    if (text.Contains(substring))
                    {
                        while (text.Contains(substring))
                        {
                            text = text.Replace(substring, newstring);
                        }
                        Console.WriteLine(text);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }                    
                }                     
            }
            Console.WriteLine($"Your password is: {text}");
        }
    }
}
