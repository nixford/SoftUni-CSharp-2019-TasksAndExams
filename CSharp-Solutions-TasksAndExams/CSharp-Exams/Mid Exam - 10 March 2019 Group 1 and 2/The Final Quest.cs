using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Final_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> wordList = Console.ReadLine().Split().ToList();
            string command = Console.ReadLine();
            List<string> commandList = new List<string>();
            string currCommand = string.Empty;

            while (command != "Stop")
            {
                commandList = command.Split().ToList();
                currCommand = commandList[0];

                if (currCommand == "Delete")
                {
                    int index = int.Parse(commandList[1]);
                    if (index + 1 >= 0 && index + 1 < wordList.Count)
                    {
                        wordList.RemoveAt(index + 1);
                    }
                }

                if (currCommand == "Swap")
                {
                    string word1 = commandList[1];
                    string word2 = commandList[2];
                    if (wordList.Contains(word1) && wordList.Contains(word2))
                    {
                        int indexWord1 = wordList.IndexOf(word1);
                        int indexWord2 = wordList.IndexOf(word2);
                        string temp = wordList[indexWord1];
                        wordList[indexWord1] = wordList[indexWord2];
                        wordList[indexWord2] = temp;
                    }
                }

                if (currCommand == "Put")
                {
                    string word = commandList[1];
                    int index = int.Parse(commandList[2]);
                    if ((index - 1) >= 0 && (index - 1) <= wordList.Count)
                    {
                        wordList.Insert(index - 1, word);
                    }
                }

                if (currCommand == "Sort")
                {
                    wordList.Sort((a, b) => b.CompareTo(a));
                }

                if (currCommand == "Replace")
                {
                    string word1 = commandList[1];
                    string word2 = commandList[2];
                    if (wordList.Contains(word2))
                    {                        
                        int indexWord2 = wordList.IndexOf(word2);
                        wordList[indexWord2] = word1;
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", wordList));
        }
    }
}
