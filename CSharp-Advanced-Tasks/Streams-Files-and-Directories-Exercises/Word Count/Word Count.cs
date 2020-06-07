using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dataBase = new Dictionary<string, int>();

            string[] words = File.ReadLines("words.txt").ToArray();

            foreach (var word in words)
            {
                if (!dataBase.ContainsKey(word))
                {
                    string currWord = word.ToString().ToLower();
                    dataBase.Add(currWord, 0);
                }
            }

            string[] text = File.ReadLines("text.txt").ToArray();           

            for (int i = 0; i < text.Length; i++)
            {
                string[] currWords = text[i].ToLower()
                    .Split(new string[] { " ", "-", ".", "," },
                     StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int j = 0; j < currWords.Length; j++)
                {
                    string currWord = currWords[j];
                       
                    if (currWord == "quick" ||
                        currWord == "is" ||
                        currWord == "fault")
                    {
                        dataBase[currWord]++;
                    }                    
                }                
            }

            File.WriteAllLines("../../../expectedResult.txt", dataBase
                .OrderByDescending(v => v.Value)
                .Where(kvp => kvp.Value > 0)
                .Select(x => x.Key + " - " + x.Value)
                .ToArray());
        }
    }
}
