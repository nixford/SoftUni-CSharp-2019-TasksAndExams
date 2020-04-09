using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputLine = Console.ReadLine().Split('-').ToArray();
            Dictionary<string, List<string>> userAndLanguage = new Dictionary<string, List<string>>();
            Dictionary<string, List<int>> userAndPoints = new Dictionary<string, List<int>>();
            List<string> bannedUsers = new List<string>();
            Dictionary<string, int> languagesOutput = new Dictionary<string, int>();

            string username = inputLine[0];
            string languageOrBanned = inputLine[1];
            int points = int.Parse(inputLine[2]);

            while (inputLine[0] != "exam finished")
            {
                username = inputLine[0];
                languageOrBanned = inputLine[1];

                if (!userAndLanguage.ContainsKey(username))
                {                    
                    points = int.Parse(inputLine[2]);

                    userAndLanguage.Add(username, new List<string>());
                    userAndLanguage[username].Add(languageOrBanned);
                    userAndPoints.Add(username, new List<int>());
                    userAndPoints[username].Add(points);
                }
                else
                {
                    userAndLanguage[username].Add(languageOrBanned);
                    userAndPoints[username].Add(points);
                }

                if (languageOrBanned == "banned")
                {
                    bannedUsers.Add(username);
                }

                inputLine = Console.ReadLine().Split('-').ToArray();
            }

            Dictionary<string, List<int>> orderedDict = userAndPoints
                    .OrderByDescending(kvp => kvp.Value.Max())
                    .ThenBy(kvp => kvp.Key)
                    .ToDictionary(a => a.Key, b => b.Value);

            Console.WriteLine("Results:");
            foreach (var item in orderedDict)
            {
                item.Value.Sort((a, b) => b.CompareTo(a));
                if (!bannedUsers.Contains(item.Key))
                {                    
                    Console.WriteLine(item.Key + " | " + item.Value[0]);
                }
            }          
            
            foreach (var item in userAndLanguage)
            {
                foreach (var currLanguage in item.Value)
                {
                    if (currLanguage != "banned")
                    {
                        if (!languagesOutput.ContainsKey(currLanguage))
                        {
                            languagesOutput.Add(currLanguage, 1);
                        }
                        else
                        {
                            languagesOutput[currLanguage]++;
                        }
                    }                   
                }                
            }

            Console.WriteLine("Submissions:");                              
            foreach (var item in languagesOutput.OrderByDescending(a => a.Value).ThenBy(a => a.Key))
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
        }
    }
}
