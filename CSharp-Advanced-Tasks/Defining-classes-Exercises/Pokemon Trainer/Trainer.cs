using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        private string name;
        private int numberOfBadges; 
        List<Pokemon> pokemonsList;
        public Trainer(string name)            
        {
            this.Name = name;
            this.numberOfBadges = 0;
            this.PokemonsList = new List<Pokemon>();
        }       
        public string Name
        { 
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public int NumberOfBadges
        {
            get
            {
                return this.numberOfBadges;
            }
            set
            {
                this.numberOfBadges = value;
            }
        }
        public List<Pokemon> PokemonsList
        {
            get
            {
                return this.pokemonsList;
            }
            set
            {
                this.pokemonsList = value;
            }
        }
    }
}
