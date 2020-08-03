using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        Hero heroMaxStrenght;
        Hero heroMaxIntelligence;
        Hero heroMaxAbility;

        private List<Hero> data;

        public int Count => this.data.Count;

        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public void Remove(string name)
        {
            int counter = 0;

            while (counter < this.data.Count)
            {
                if (this.data[counter].Name == name)
                {
                    this.data.Remove(this.data[counter]);
                    break;
                }

                counter++;
            }                 
        }

        public Hero GetHeroWithHighestStrength()
        {
            int maxStrenghtValue = int.MinValue;

            int counter = 0;            

            while (counter < this.data.Count)
            {
                if (this.data[counter].Item.Strength > maxStrenghtValue)
                {
                    maxStrenghtValue = this.data[counter].Item.Strength;
                    heroMaxStrenght = this.data[counter];                    
                }
                counter++;
            }

            return heroMaxStrenght;
        }

        public Hero GetHeroWithHighestAbility()
        {
            int maxAbilityValue = int.MinValue;

            int counter = 0;            

            while (counter < this.data.Count)
            {
                if (this.data[counter].Item.Ability > maxAbilityValue)
                {
                    maxAbilityValue = this.data[counter].Item.Ability;
                    heroMaxAbility = this.data[counter];
                }
                counter++;
            }

            return heroMaxAbility;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            int maxIntelligenceValue = int.MinValue;

            int counter = 0;            

            while (counter < this.data.Count)
            {
                if (this.data[counter].Item.Intelligence > maxIntelligenceValue)
                {
                    maxIntelligenceValue = this.data[counter].Item.Intelligence;
                    heroMaxIntelligence = this.data[counter];
                }
                counter++;
            }

            return heroMaxIntelligence;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var hero in this.data)
            {
                sb
                .AppendLine($"Hero: {hero.Name} - {hero.Level}lvl")
                .AppendLine($"Item:")
                .AppendLine($"    *Strength: {hero.Item.Strength}")
                .AppendLine($"    * Ability: {hero.Item.Ability}")
                .AppendLine($"    * Intelligence: {hero.Item.Intelligence}");                
            }
            return sb.ToString().TrimEnd();
        }
    }
}
