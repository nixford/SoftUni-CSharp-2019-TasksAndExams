using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputLine = Console.ReadLine().Split(':');
            Dictionary<string, string> contestsAndPass = new Dictionary<string, string>();

            while (inputLine[0] != "end of contests")
            {
                string contest = inputLine[0];
                string passForContest = inputLine[1];

                if (!contestsAndPass.ContainsKey(contest))
                {
                    contestsAndPass.Add(contest, passForContest);
                }
                inputLine = Console.ReadLine().Split(':');
            }

            string[] submissionsArr = Console.ReadLine()
                .Split(new string[] { "=>" }, 
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            Dictionary<string, Dictionary<string, int>> namesContestsPoints = 
                new Dictionary<string, Dictionary<string, int>>();

            while (submissionsArr[0] != "end of submissions")
            {
                string contest = submissionsArr[0];
                string password = submissionsArr[1];
                string username = submissionsArr[2];
                int points = int.Parse(submissionsArr[3]);

                if (contestsAndPass.ContainsKey(contest) &&
                    contestsAndPass.ContainsValue(password))
                {
                    if (!namesContestsPoints.ContainsKey(username))
                    {
                        namesContestsPoints.Add(username, new Dictionary<string, int>());
                        namesContestsPoints[username].Add(contest, points);
                    }

                    if (namesContestsPoints[username].ContainsKey(contest))
                    {
                        if (namesContestsPoints[username][contest] < points)
                        {
                            namesContestsPoints[username][contest] = points;
                        }
                    }
                    else
                    {
                        namesContestsPoints[username].Add(contest, points);
                    }                    
                }
                submissionsArr = Console.ReadLine()
                .Split(new string[] { "=>" },
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            Dictionary<string, int> totalPoints = new Dictionary<string, int>();

            foreach (var kvp in namesContestsPoints)
            {
                totalPoints[kvp.Key] = kvp.Value.Values.Sum();
            }

            string bestName = totalPoints.Keys.Max();
            int bestPoints = totalPoints.Values.Max();

            foreach (var item in totalPoints)
            {
                if (item.Value == bestPoints)
                {
                    Console.WriteLine($"Best candidate is {item.Key} with total {item.Value} points.");
                }
            }

            Console.WriteLine("Ranking:");
            foreach (var name in namesContestsPoints.OrderBy(k => k.Key))
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
