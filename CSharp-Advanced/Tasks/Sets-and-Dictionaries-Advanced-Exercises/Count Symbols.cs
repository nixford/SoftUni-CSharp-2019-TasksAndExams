using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Dictionary<char, int> dataBase = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!dataBase.ContainsKey(text[i]))
                {
                    dataBase.Add(text[i], 1);
                }
                else
                {
                    dataBase[text[i]]++;
                }
            }

            foreach (var kvp in dataBase.OrderBy(k => k.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
