using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double totalCoins = 0;
            string command = string.Empty;

            while (input != "Start")
            {                
                double coins = double.Parse(input);                
                if (input != "Start" && coins == 0.1 || coins == 0.2 || coins == 0.5 || coins == 1 || coins == 2)
                {
                    totalCoins = totalCoins + coins;
                }
                else if (input != "Start" && coins != 0.1 || coins != 0.2 || coins != 0.5 || coins != 1 || coins != 2)
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }
                else if (input == "Start")
                {
                    break;
                }
                input = Console.ReadLine();                
            }

            while (true)
            {
                command = Console.ReadLine();
                if (command == "End")
                {
                    Console.WriteLine($"Change: {totalCoins:f2}");
                    break;
                }
                if (command == "Nuts")
                {
                    if (totalCoins >= 2.0)
                    {
                        Console.WriteLine("Purchased nuts");
                        totalCoins = totalCoins - 2.0;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (command == "Water")
                {
                    if (totalCoins >= 0.7)
                    {
                        Console.WriteLine($"Purchased water");
                        totalCoins = totalCoins - 0.7;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (command == "Crisps")
                {
                    if (totalCoins >= 1.5)
                    {
                        Console.WriteLine("Purchased crisps");
                        totalCoins = totalCoins - 1.5;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (command == "Soda")
                {
                    if (totalCoins >= 0.8)
                    {
                        Console.WriteLine("Purchased soda");
                        totalCoins = totalCoins - 0.8;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (command == "Coke")
                {
                    if (totalCoins >= 1.0)
                    {
                        Console.WriteLine($"Purchased coke");
                        totalCoins = totalCoins - 1.0;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");                   
                }
            }
        }
    }
}
