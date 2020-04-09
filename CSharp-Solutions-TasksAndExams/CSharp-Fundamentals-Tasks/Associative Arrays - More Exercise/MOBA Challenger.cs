using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputLine = Console.ReadLine()
                .Split(new string[] { " -> " }, 
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            
            Dictionary<string, Dictionary<string, int>> dataBase 
                = new Dictionary<string, Dictionary<string, int>>();

            string player = string.Empty;
            string position = string.Empty;
            int skill = 0;

            while (inputLine[0] != "Season end")
            {
                string[] temp = inputLine[0].Split(' ').ToArray();
                if (temp.Length > 1)
                {
                    if (temp[1] == "vs")
                    {
                        string player1 = temp[0];
                        string player2 = temp[2];

                        if (dataBase.ContainsKey(player1) && dataBase.ContainsKey(player2))
                        {
                            foreach (var kvp in dataBase[player2])
                            {
                                if (dataBase[player1].ContainsKey(kvp.Key))
                                {
                                    if (dataBase[player1][position] > dataBase[player2][position])
                                    {
                                        dataBase.Remove(player2);
                                    }
                                    else if (dataBase[player1][position] < dataBase[player2][position])
                                    {
                                        dataBase.Remove(player1);
                                    }                                    
                                }
                            }
                        }
                    }
                }
                else
                {
                    player = inputLine[0];
                    position = inputLine[1];
                    skill = int.Parse(inputLine[2]);
                    if (!dataBase.ContainsKey(player))
                    {
                        dataBase.Add(player, new Dictionary<string, int>());
                        dataBase[player].Add(position, skill);
                    }
                    else
                    {
                        if (!dataBase[player].ContainsKey(position))
                        {
                            dataBase[player].Add(position, skill);
                        }
                        else
                        {
                            if (dataBase[player][position] < skill)
                            {
                                dataBase[player][position] = skill;
                            }
                        }
                    }                   
                }
                inputLine = Console.ReadLine()
                .Split(new string[] { " -> " },
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            
            dataBase = dataBase
                .OrderByDescending(x => x.Value.Values.Sum())
                .ToDictionary(x => x.Key, x => x.Value.OrderByDescending(y => y.Value).ToDictionary(y => y.Key, y => y.Value));

            foreach (var item in dataBase)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Values.Sum()} skill");
                foreach (var kvp in item.Value.OrderByDescending(v => v.Value))
                {
                    Console.WriteLine($"- {kvp.Key} <::> {kvp.Value}");
                }
            }
        }
    }
}
