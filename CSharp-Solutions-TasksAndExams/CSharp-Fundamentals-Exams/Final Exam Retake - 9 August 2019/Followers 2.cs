using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Followers_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Dictionary<string, List<int>> dataBase = new Dictionary<string, List<int>>();

            while ((input = Console.ReadLine()) != "Log out")
            {
                string[] inputLine = input
                    .Split(new string[] { ": " }, 
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (inputLine[0] == "New follower")
                {
                    string username = inputLine[1];
                    if (!dataBase.ContainsKey(username))
                    {
                        dataBase.Add(username, new List<int>());
                        dataBase[username].Add(0);
                        dataBase[username].Add(0);
                    }
                }
                else if (inputLine[0] == "Like")
                {
                    string username = inputLine[1];
                    int count = int.Parse(inputLine[2]);
                    if (!dataBase.ContainsKey(username))
                    {
                        dataBase.Add(username, new List<int>());
                        dataBase[username].Add(count);
                        dataBase[username].Add(0);
                    }
                    else
                    {
                        dataBase[username][0] += count;
                    }
                }
                else if (inputLine[0] == "Comment")
                {
                    string username = inputLine[1];
                    if (!dataBase.ContainsKey(username))
                    {
                        dataBase.Add(username, new List<int>());
                        dataBase[username].Add(0);
                        dataBase[username].Add(1);
                    }
                    else
                    {
                        dataBase[username][0] += 0;
                        dataBase[username][1] += 1;
                    }
                }
                else if (inputLine[0] == "Blocked")
                {
                    string username = inputLine[1];
                    if (dataBase.ContainsKey(username))
                    {
                        dataBase.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} doesn't exist.");
                    }
                }
            }

            Console.WriteLine($"{dataBase.Keys.Count} followers");
            foreach (var kvp in dataBase.OrderByDescending(v => v.Value[0]).ThenBy(k => k.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value[0] + kvp.Value[1]}");
            }
        }
    }
}
