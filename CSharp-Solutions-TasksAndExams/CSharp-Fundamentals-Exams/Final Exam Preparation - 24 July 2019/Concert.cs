using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concert2
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            Dictionary<string, List<string>> bandAndMembers = new Dictionary<string, List<string>>();
            Dictionary<string, int> bandAndTime = new Dictionary<string, int>();

            while ((command = Console.ReadLine()) != "start of concert")
            {
                string[] commandLine = command
                    .Split(new string[] { "; ", ", " }, 
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (commandLine[0] == "Add")
                {
                    string currBandName = commandLine[1];                    
                    for (int i = 2; i < commandLine.Length; i++)
                    {
                        string currMember = commandLine[i];
                        if (!bandAndMembers.ContainsKey(currBandName))
                        {
                            bandAndMembers.Add(currBandName, new List<string>());
                            if (!bandAndMembers[currBandName].Contains(currMember))
                            {
                                bandAndMembers[currBandName].Add(currMember);
                            }                            
                        }
                        else
                        {
                            if (!bandAndMembers[currBandName].Contains(currMember))
                            {
                                bandAndMembers[currBandName].Add(currMember);
                            }
                        }
                    }
                }
                else if (commandLine[0] == "Play")
                {
                    string bandName2 = commandLine[1];
                    int time = int.Parse(commandLine[2]);

                    if (!bandAndTime.ContainsKey(bandName2))
                    {
                        bandAndTime.Add(bandName2, time);
                    }
                    else
                    {
                        bandAndTime[bandName2] += time;
                    }
                }                
            }
            string bandName = Console.ReadLine();

            Console.WriteLine($"Total time: {bandAndTime.Values.Sum()}");
            foreach (var band in bandAndTime.OrderByDescending(v => v.Value).ThenBy(k => k.Key))
            {
                Console.WriteLine($"{band.Key} -> {band.Value}");
            }

            Console.WriteLine(bandName);
            foreach (var member in bandAndMembers[bandName])
            {
                Console.WriteLine($"=> {member}");
            }
        }
    }
}
