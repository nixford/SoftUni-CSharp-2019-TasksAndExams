using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> book = new Dictionary<string, List<string>>();
            string input;

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] inputArg = input
                    .Split(new string[] { " | ", " -> " }, 
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (input.Contains("|"))
                {
                    string side = inputArg[0];
                    string user = inputArg[1];
                    if (!book.ContainsKey(side))
                    { 
                        book[side] = new List<string>();                        
                    }  

                    if (!book.Values.Any(l => l.Contains(user)))
                    {
                        book[side].Add(user);                        
                    }
                }
                else if (input.Contains("->"))
                {
                    string user = inputArg[0];
                    string side = inputArg[1];

                    foreach (var kvp in book)
                    {
                        if (kvp.Value.Contains(user))
                        {
                            kvp.Value.Remove(user);
                        }                        
                    }
                    if (!book.ContainsKey(side))
                    {
                        book[side] = new List<string>();
                    }
                    book[side].Add(user);
                    Console.WriteLine($"{user} joins the {side} side!");
                }                
            }
            Dictionary<string, List<string>> orderedBook = book
                    .Where(kvp => kvp.Value.Count > 0)
                    .OrderByDescending(kvp => kvp.Value.Count)
                    .ThenBy(kvp => kvp.Key)
                    .ToDictionary(a => a.Key, b => b.Value);

            foreach (var kvp in orderedBook)
            {
                string currentSide = kvp.Key;
                List<string> currentSideUsers = kvp.Value
                    .OrderBy(u => u)
                    .ToList();

                Console.WriteLine($"Side: {currentSide}, Members: {currentSideUsers.Count}");

                foreach (var user in currentSideUsers)
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}
