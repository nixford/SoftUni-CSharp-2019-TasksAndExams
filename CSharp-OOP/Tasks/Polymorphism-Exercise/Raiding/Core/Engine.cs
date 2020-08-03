using Raiding.HeroSchool;
using Raiding.IO;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace Raiding.Core
{
    public class Engine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IHeroSchool heroSchool;
        private ICollection<IBaseHero> heroesList;

        public Engine(IReader reader, IWriter writer, IHeroSchool heroSchool)
        {
            this.reader = reader; // FileReader();
            this.writer = writer;
            this.heroSchool = heroSchool;
            this.heroesList = new List<IBaseHero>();
        }

        public void Run()
        {
            
            int lines = int.Parse(this.reader.CustomReadLine());
            int count = 0;

            while (lines != count)
            {
                string heroName = this.reader.CustomReadLine();
                string heroType = this.reader.CustomReadLine();

                try
                {
                    IBaseHero baseHero = CreateHero(heroName, heroType);

                    heroesList.Add(baseHero);

                    count++;
                }
                catch (Exception ex)
                {
                    this.writer.CustomWriteLine(ex.Message);
                }
            }

            int boss = int.Parse(this.reader.CustomReadLine());
            int totalHeroSum = 0;

            foreach (IBaseHero hero in heroesList)
            {
                totalHeroSum += hero.Power;
                this.writer.CustomWriteLine(hero.CastAbility());
                if (totalHeroSum >= boss)
                {
                    this.writer.CustomWriteLine("Victory!");                    
                    return;
                }
            }

            Console.WriteLine("Defeat...");
        }


        private IBaseHero CreateHero(string heroName, string heroType)
        {  
            IBaseHero hero = this.heroSchool.CreateHero(heroName, heroType);

            return hero;
        }
    }
}
