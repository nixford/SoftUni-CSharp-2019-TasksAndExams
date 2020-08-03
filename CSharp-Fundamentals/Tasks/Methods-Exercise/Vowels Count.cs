using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            GetVowelsNumber(text);
            Console.WriteLine(GetVowelsNumber(text));
        }

        static int GetVowelsNumber(string text)
        {
            int numberOfVowels = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 'a' || text[i] == 'e' || text[i] == 'i' || text[i] == 'o' || text[i] == 'u')
                {
                    numberOfVowels++;
                }
            }
            return numberOfVowels;
        }
    }
}
