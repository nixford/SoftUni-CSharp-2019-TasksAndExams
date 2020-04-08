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
            // Loading heroes into dictionary
            int heroesNumber = int.Parse(Console.ReadLine());

            Dictionary<string, List<int>> dataBase = new Dictionary<string, List<int>>();                

            for (int i = 0; i < heroesNumber; i++)
            {                
                string[] inputLine = Console.ReadLine().Split(' ').ToArray();
                string heroName = inputLine[0];
                int hitPoints = int.Parse(inputLine[1]);
                int manaPints = int.Parse(inputLine[2]);

                if (!dataBase.ContainsKey(heroName))
                {
                    dataBase.Add(heroName, new List<int>());
                    dataBase[heroName].Add(hitPoints);
                    dataBase[heroName].Add(manaPints);
                }
            }

            // Processing the commands
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandLine = command
                    .Split(new string[] { " - " }, 
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (commandLine[0] == "CastSpell")
                {
                    string heroName = commandLine[1];
                    int manaPointsNeeded = int.Parse(commandLine[2]);
                    string spellName = commandLine[3];

                    if (dataBase[heroName][1] - manaPointsNeeded >= 0)
                    {
                        dataBase[heroName][1] -= manaPointsNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {dataBase[heroName][1]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (commandLine[0] == "TakeDamage")
                {
                    string heroName = commandLine[1];
                    int damage = int.Parse(commandLine[2]);
                    string attacker = commandLine[3];

                    if (dataBase[heroName][0] - damage > 0)
                    {
                        dataBase[heroName][0] -= damage;
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {dataBase[heroName][0]} HP left!");
                    }
                    else
                    {
                        dataBase.Remove(heroName);
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                    }
                }
                else if (commandLine[0] == "Recharge")
                {
                    string heroName = commandLine[1];
                    int amountManaPointsRecharge = int.Parse(commandLine[2]);

                    if (dataBase[heroName][1] + amountManaPointsRecharge <= 200)
                    {
                        dataBase[heroName][1] += amountManaPointsRecharge;
                        Console.WriteLine($"{heroName} recharged for {amountManaPointsRecharge} MP!");
                    }
                    else
                    {                        
                        Console.WriteLine($"{heroName} recharged for {200 - dataBase[heroName][1]} MP!");
                        dataBase[heroName][1] = 200;
                    }
                }
                else if (commandLine[0] == "Heal")
                {
                    string heroName = commandLine[1];
                    int amountHeal = int.Parse(commandLine[2]);

                    if (dataBase[heroName][0] + amountHeal <= 100)
                    {
                        dataBase[heroName][0] += amountHeal;
                        Console.WriteLine($"{heroName} healed for {amountHeal} HP!");
                    }
                    else
                    {                       
                        Console.WriteLine($"{heroName} healed for {100 - dataBase[heroName][0]} HP!");
                        dataBase[heroName][0] = 100;
                    }
                }
            }        

            foreach (var kvp in dataBase.OrderByDescending(v => v.Value[0]).ThenBy(k => k.Key))
            {
                Console.WriteLine(kvp.Key);
                Console.WriteLine($" HP: {kvp.Value[0]}");
                Console.WriteLine($" MP: {kvp.Value[1]}");
            }
        }
    }
}