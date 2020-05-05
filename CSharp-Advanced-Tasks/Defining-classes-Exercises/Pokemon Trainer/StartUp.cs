using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string line = string.Empty;

            Dictionary<string, Trainer> collectionOfTrainers = new Dictionary<string, Trainer>();

            while ((line = Console.ReadLine()) != "Tournament")
            {
                string[] lineArgs = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string trainerName = lineArgs[0];
                string pokemonName = lineArgs[1];
                string pokemonElement = lineArgs[2];
                int pokemonHealth = int.Parse(lineArgs[3]);

                
                

                if (!collectionOfTrainers.ContainsKey(trainerName))
                {
                    collectionOfTrainers.Add(trainerName, new Trainer(trainerName));
                }                

                Trainer currTrainer = collectionOfTrainers[trainerName];

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);                

                currTrainer.PokemonsList.Add(pokemon);
            }

            string commands = string.Empty;

            while ((commands = Console.ReadLine()) != "End")
            {
                string element = commands;

                foreach (var trainer in collectionOfTrainers)
                {
                    if (trainer.Value.PokemonsList.Any(p => p.Element == element))
                    {
                        trainer.Value.NumberOfBadges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Value.PokemonsList)
                        {
                            pokemon.Health -= 10;                   
                        }
                        trainer.Value.PokemonsList.RemoveAll(x => x.Health <= 0);
                    }
                }                
            }

            var result = collectionOfTrainers
                .OrderByDescending(x => x.Value.NumberOfBadges)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} {item.Value.NumberOfBadges} {item.Value.PokemonsList.Count}");
            }
        }
    }
}
