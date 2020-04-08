using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inbox_Manager2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Dictionary<string, List<string>> dataBase = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] inputLine = input
                    .Split(new string[] { "-", ">" }, 
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (inputLine[0] == "Add")
                {
                    string username = inputLine[1];
                    if (!dataBase.ContainsKey(username))
                    {
                        dataBase.Add(username, new List<string>());
                    }
                    else
                    {
                        Console.WriteLine($"{username} is already registered");
                    }
                }
                else if (inputLine[0] == "Send")
                {
                    string username = inputLine[1];
                    string email = inputLine[2];
                    if (dataBase.ContainsKey(username))
                    {
                        dataBase[username].Add(email);
                    }
                }
                else if (inputLine[0] == "Delete")
                {
                    string username = inputLine[1];                    
                    if (dataBase.ContainsKey(username))
                    {
                        dataBase.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} not found!");
                    }
                }
            }
            Console.WriteLine($"Users count: {dataBase.Keys.Count}");
            foreach (var kvp in dataBase.OrderByDescending(v => v.Value.Count).ThenBy(k => k.Key))
            {
                Console.WriteLine(kvp.Key);
                foreach (var email in kvp.Value)
                {
                    Console.WriteLine($"- {email}");
                }
            }
        }
    }
}
