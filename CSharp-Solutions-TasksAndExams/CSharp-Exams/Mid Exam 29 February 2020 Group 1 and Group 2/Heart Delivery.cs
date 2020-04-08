using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] houses = Console.ReadLine().Split('@').Select(int.Parse).ToArray();
            string command = string.Empty;
            int currIndex = 0;

            while ((command = Console.ReadLine()) != "Love!")
            {
                string[] commandList = command.Split(' ').ToArray();                
                int length = int.Parse(commandList[1]);

                if (length + currIndex < houses.Length)
                {
                    currIndex = currIndex + length;
                    if (houses[currIndex] - 2 > 0)
                    {
                        houses[currIndex] -= 2;
                    }
                    else // if houses[currIndex] - 2 <= 0;
                    {
                        if (houses[currIndex] == 0)
                        {
                            Console.WriteLine($"Place {currIndex} already had Valentine's day.");
                        }
                        else
                        {
                            houses[currIndex] = 0;
                            Console.WriteLine($"Place {currIndex} has Valentine's day.");
                        }
                    }                   
                }
                else // if length + currIndex >= houses.Length
                {
                    currIndex = 0;
                    if (houses[currIndex] - 2 > 0)
                    {
                        houses[currIndex] -= 2;
                    }
                    else 
                    {
                        if (houses[currIndex] == 0)
                        {
                            Console.WriteLine($"Place {currIndex} already had Valentine's day.");
                        }
                        else
                        {
                            houses[currIndex] = 0;
                            Console.WriteLine($"Place {currIndex} has Valentine's day.");
                        }               
                    }
                }                
            }
            Console.WriteLine($"Cupid's last position was {currIndex}.");
            if (houses.Sum() == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                int count = 0;
                for (int i = 0; i < houses.Length; i++)
                {
                    if (houses[i] != 0)
                    {
                        count++;
                    }
                }
                Console.WriteLine($"Cupid has failed {count} places.");
            }
        }
    }
}
