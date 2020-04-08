using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine()
                .Split(new string[] { "|", " " }, 
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int health = 100;
            int bitcoins = 0;
            int roomCount = 0;
            bool madeIt = true;

            for (int i = 0; i < rooms.Length; i+= 2)
            {
                roomCount++;
                string monsterOrHealthOrBit = rooms[i];
                int amount = int.Parse(rooms[i + 1]);

                if (monsterOrHealthOrBit == "potion")
                {
                    if (amount + health <= 100)
                    {
                        Console.WriteLine($"You healed for {amount} hp.");
                        health += amount;
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                    else
                    {
                        Console.WriteLine($"You healed for {100 - health} hp.");
                        health = 100;
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                }
                else if (monsterOrHealthOrBit == "chest")
                {
                    bitcoins += amount;
                    Console.WriteLine($"You found {amount} bitcoins.");
                }
                else
                {
                    health -= amount;
                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {monsterOrHealthOrBit}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {monsterOrHealthOrBit}.");
                        madeIt = false;
                        break;
                    }
                }               
            }
            if (madeIt)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }
            else
            {
                Console.WriteLine($"Best room: {roomCount}");
            }
        }
    }
}
