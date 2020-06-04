using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator2
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var inputArs = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var command = inputArs[0];
                try
                {
                    switch (command)
                    {
                        case "Team":
                            teams.Add(new Team(inputArs[1]));
                            break;

                        case "Add":
                            if (!teams.Any(t => t.Name == inputArs[1]))
                            {
                                throw new ArgumentException($"Team {inputArs[1]} does not exist.");
                            }
                            else
                            {
                                var currentTeam = teams.First(t => t.Name == inputArs[1]);
                                currentTeam.AddPlayer(new Player(inputArs[2], int.Parse(inputArs[3]), int.Parse(inputArs[4]), int.Parse(inputArs[5]), int.Parse(inputArs[6]), int.Parse(inputArs[7])));
                            }
                            break;

                        case "Remove":
                            var teamToRemove = teams.First(t => t.Name == inputArs[1]);
                            teamToRemove.RemovePlayer(inputArs[2]);
                            break;

                        case "Rating":
                            if (!teams.Any(t => t.Name == inputArs[1]))
                            {
                                throw new ArgumentException($"Team {inputArs[1]} does not exist.");
                            }
                            else
                            {
                                Console.WriteLine(teams.First(t => t.Name == inputArs[1]).ToString());
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
