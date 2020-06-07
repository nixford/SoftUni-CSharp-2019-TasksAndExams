using System;
using System.IO;
using System.Linq;

namespace Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = File.ReadAllLines("./text.txt"); 

            int letterCount = 0;
            int punctCount = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char[] input = text[i].ToCharArray();
                for (int j = 0; j < input.Length; j++)
                {
                    if (Char.IsLetter(input[j]))
                    {
                        letterCount++;
                    }

                    if (Char.IsPunctuation(input[j]))
                    {
                        punctCount++;
                    }                    
                }
                text[i] = $"Line {i + 1}: {text[i]} ({letterCount})({punctCount})";
                letterCount = 0;
                punctCount = 0;
            }

            File.WriteAllLines("../../../output.txt", text);
        }
    }
}
