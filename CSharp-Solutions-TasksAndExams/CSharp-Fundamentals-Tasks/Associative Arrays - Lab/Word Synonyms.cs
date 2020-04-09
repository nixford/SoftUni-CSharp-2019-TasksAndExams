using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());            
            Dictionary<string, List<string>> synonimDict = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonim = Console.ReadLine();
                if (!synonimDict.ContainsKey(word))
                {
                    synonimDict.Add(word, new List<string>());
                    synonimDict[word].Add(synonim);
                }
                else
                {
                    synonimDict[word].Add(synonim);
                }
            }

            foreach (var item in synonimDict)
            {
                Console.WriteLine(item.Key + " - " + string.Join(", ", item.Value));
            }
        }
    }
}
