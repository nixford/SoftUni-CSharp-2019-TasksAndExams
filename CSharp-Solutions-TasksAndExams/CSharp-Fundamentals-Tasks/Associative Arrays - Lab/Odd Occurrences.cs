using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputArr = Console.ReadLine()
                .Split(' ')
                .ToArray();
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach (var item in inputArr)
            {
                string wordToLowerCase = item.ToLower();
                if (dictionary.ContainsKey(wordToLowerCase))
                {
                    dictionary[wordToLowerCase]++;                    
                }
                else
                {
                    dictionary.Add(wordToLowerCase, 1);
                }
            }

            foreach (var item in dictionary)
            {
                if (item.Value % 2 != 0)
                {
                    Console.Write(item.Key + " ");
                }               
            }
            Console.WriteLine();
        }
    }
}
