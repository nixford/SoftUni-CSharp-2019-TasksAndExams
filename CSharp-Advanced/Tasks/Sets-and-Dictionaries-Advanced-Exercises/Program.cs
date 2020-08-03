using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {           
            string input = string.Empty;
            
            Dictionary<string, string> contAndPassDict =
                new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> nameAndContPointDict =
                new SortedDictionary<string, Dictionary<string, int>>();

            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] str = input.Split(':');
                string contest = str[0];
                string password = str[1];
                contAndPassDict.Add(contest, password);
            }

            string inputColl = string.Empty;

            while ((inputColl = Console.ReadLine()) != "end of submissions")
            {
                string[] str2 = inputColl
                    .Split(new string[] { "=>" }, 
                    StringSplitOptions.None)
                    .ToArray();
                string contestColl = str2[0];
                string passwordColl = str2[1];
                string nameCollection = str2[2];
                int pointColl = int.Parse(str2[3]);
                if (contAndPassDict.ContainsKey(contestColl)
                    && contAndPassDict.ContainsValue(passwordColl))
                {
                    if (nameAndContPointDict.ContainsKey(nameCollection) == false)
                    {
                        nameAndContPointDict.Add(nameCollection, new Dictionary<string, int>());
                        nameAndContPointDict[nameCollection].Add(contestColl, pointColl);
                    }
                    if (nameAndContPointDict[nameCollection].ContainsKey(contestColl))
                    {
                        if (nameAndContPointDict[nameCollection][contestColl] < pointColl)
                        {
                            nameAndContPointDict[nameCollection][contestColl] = pointColl;
                        }
                    }
                    else
                    {
                        nameAndContPointDict[nameCollection].Add(contestColl, pointColl);
                    }
                }

            }
            Dictionary<string, int> usernameTotalPoints = new Dictionary<string, int>();
            foreach (var kvp in nameAndContPointDict)
            {
                usernameTotalPoints[kvp.Key] = kvp.Value.Values.Sum();
            }
            string bestName = usernameTotalPoints
                .Keys
                .Max();
            int bestPoints = usernameTotalPoints
                .Values
                .Max();

            foreach (var kvp in usernameTotalPoints)
            {
                if (kvp.Value == bestPoints)
                {
                    Console.WriteLine($"Best candidate is {kvp.Key} with total {kvp.Value} points.");

                }
            }
            Console.WriteLine("Ranking:");
            foreach (var name in nameAndContPointDict)
            {
                Dictionary<string, int> dict = name.Value;
                dict = dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                Console.WriteLine("{0}", name.Key);
                foreach (var kvp in dict)
                {
                    Console.WriteLine("#  {0} -> {1}", kvp.Key, kvp.Value);
                }

            }
        }
    }
}