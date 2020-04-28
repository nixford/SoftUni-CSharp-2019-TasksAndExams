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

            FileStream stream = new FileStream("words.txt", FileMode.OpenOrCreate);
            StreamReader readerWord = new StreamReader(stream);

            using (readerWord)
            {
                string[] words = readerWord.ReadLine().Split().ToArray();

                for (int i = 0; i < words.Length; i++)
                {
                    string currWord = words[i].ToLower();
                    if (!dataBase.ContainsKey(currWord))
                    {
                        dataBase.Add(currWord, 0);
                    }                    
                }
            }

            FileStream streamSecond = new FileStream("Input.txt", FileMode.OpenOrCreate);
            StreamReader readerInput = new StreamReader(streamSecond);
            using (readerInput)
            {
                string[] inputWords = readerInput.ReadToEnd()
                    .Split(new string[] { " ", "-", ".", "\r\n", "," }, 
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                for (int i = 0; i < inputWords.Length; i++)
                {
                    string currWord = inputWords[i].ToLower();
                    if (!dataBase.ContainsKey(currWord))
                    {
                        dataBase.Add(currWord, 0);
                    }
                    else
                    {
                        dataBase[currWord]++;
                    }
                }
            }            

            FileStream streamOutput = new FileStream("Output.txt", FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(streamOutput);
            using (writer)
            {
                foreach (var kvp in dataBase.OrderByDescending(v => v.Value))
                {
                    if (kvp.Key != null && 
                        kvp.Key != string.Empty && 
                        kvp.Value > 0)
                    {
                        writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                    }                    
                }
            }
        }       
    }
}
