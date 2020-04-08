using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine()
                .Split(new string[] { " | " }, 
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            Dictionary<string, List<string>> wordsAndDefinitions = 
                new Dictionary<string, List<string>>();
            for (int i = 0; i < input1.Length; i++)
            {
                string[] currWordAndDefinition = input1[i]
                    .Split(new string[] { ": " }, 
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();               
                if (!wordsAndDefinitions.ContainsKey(currWordAndDefinition[0]))
                {
                    wordsAndDefinitions.Add(currWordAndDefinition[0], new List<string>());
                    wordsAndDefinitions[currWordAndDefinition[0]].Add(currWordAndDefinition[1]);
                }
                else
                {
                    wordsAndDefinitions[currWordAndDefinition[0]].Add(currWordAndDefinition[1]);
                }
            }

            string[] input2 = Console.ReadLine()
                .Split(new string[] { " | " }, 
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            for (int i = 0; i < input2.Length; i++)
            {
                foreach (var item in wordsAndDefinitions)
                {
                    if (input2[i] == item.Key)
                    {
                        Console.WriteLine($"{input2[i]}");
                        foreach (var descrition in item.Value.OrderByDescending(v => v.Length))
                        {
                            Console.WriteLine(" -" + descrition);
                        }                        
                    }
                }
            }

            string input3 = Console.ReadLine();
            if (input3 == "List")
            {
                foreach (var kvp in wordsAndDefinitions.OrderBy(k => k.Key))
                {
                    Console.Write(kvp.Key + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
