using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] characters = Console.ReadLine().ToCharArray();
            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            for (int i = 0; i < characters.Length; i++)
            {
                if (characters[i] != ' ')
                {
                    if (!dictionary.ContainsKey(characters[i]))
                    {
                        dictionary.Add(characters[i], 1);
                    }
                    else
                    {
                        dictionary[characters[i]]++;
                    }
                }                
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key + " -> " + item.Value);
            }
        }
    }
}
