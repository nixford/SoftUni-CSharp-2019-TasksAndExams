using System;
using System.Collections.Generic;
using System.Linq;

namespace The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Dictionary<string, Dictionary<string, int>> dataBase =
                new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> followingsDatabase = new Dictionary<string, int>();

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] commandLine = input.Split().ToArray();
                string name = commandLine[0];
                string currCommand = commandLine[1];

                if (currCommand == "joined")
                {
                    if (!dataBase.ContainsKey(name))
                    {
                        dataBase.Add(name, new Dictionary<string, int>());
                        followingsDatabase.Add(name, 0);
                    }
                }
                else if (currCommand == "followed")
                {
                    string secondVlogger = commandLine[2];

                    if (dataBase.ContainsKey(name) &&
                        dataBase.ContainsKey(secondVlogger)) //If any of the given vlogernames does not exist in you collection, ignore that command
                    {
                        if (name != secondVlogger) // Vlogger cannot follow himself
                        {
                            if (!dataBase[secondVlogger].ContainsKey(name)) // Vlogger cannot follow someone he is already a follower of
                            {
                                dataBase[secondVlogger].Add(name, 0);
                                if (!followingsDatabase.ContainsKey(name))
                                {
                                    followingsDatabase.Add(name, 1);
                                }
                                else
                                {
                                    followingsDatabase[name] += 1;
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"The V-Logger has a total of {dataBase.Keys.Count} vloggers in its logs.");

            foreach (var kvp in dataBase
                .OrderByDescending(v => v.Value.Keys.Count)) // Then you have to print the most famous vlogger
            {
                Console.WriteLine($"1. {kvp.Key} : {kvp.Value.Keys.Count} followers, {followingsDatabase[kvp.Key]} following");
                foreach (var (followers, followings) in kvp.Value.OrderBy(k => k.Key))
                {
                    Console.WriteLine($"*  {followers}");
                }
                break;
            }

            int count = 0;
            foreach (var kvp in dataBase
                .OrderByDescending(v => v.Value.Keys.Count))
            {
                if (count > 0)
                {
                    Console.WriteLine($"{count + 1}. {kvp.Key} : {kvp.Value.Keys.Count} followers, {followingsDatabase[kvp.Key]} following");
                }
                count++;
            }
        }
    }
}