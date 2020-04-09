using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentBalance = double.Parse(Console.ReadLine());
            string command = string.Empty;
            double firstBallance = currentBalance;            
            double price = 0;
            double moneyLeft = 0;
            double totalForGames = 0;

            while (true)
            {
                command = Console.ReadLine();
                if (command == "Game Time") break;
                switch (command)
                {
                    case "OutFall 4": price = 39.99; break;
                    case "CS: OG": price = 15.99; break;
                    case "Zplinter Zell": price = 19.99; break;
                    case "Honored 2": price = 59.99; break;
                    case "RoverWatch": price = 29.99; break;
                    case "RoverWatch Origins Edition": price = 39.99; break;
                    default: Console.WriteLine("Not Found"); break;
                }
                if (currentBalance < price)
                {
                    Console.WriteLine("Too Expensive");
                    continue;
                } 
                else if (currentBalance >= price)
                {
                    currentBalance = currentBalance - price;
                    if (currentBalance == 0)
                    {
                        Console.WriteLine("Out of money!");
                    }
                    else
                    {
                        Console.WriteLine($"Bought {command}");
                    }
                }                
            }
            if (currentBalance != 0)
            {
                moneyLeft = currentBalance;
                totalForGames = firstBallance - currentBalance;
                Console.WriteLine($"Total spent: ${totalForGames:f2}. Remaining: ${moneyLeft:f2}");
            }            
        }
    }
}
