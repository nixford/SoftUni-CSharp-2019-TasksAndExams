using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter_Strike
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalEnergy = int.Parse(Console.ReadLine());
            string command = string.Empty;

            int distance = 0;
            int winCount = 0;
            bool thereIsEnergy = true;

            while ((command = Console.ReadLine()) != "End of battle")
            {
                distance = int.Parse(command);
                if (totalEnergy >= distance)
                {
                    totalEnergy -= distance;
                    winCount++;
                    if (winCount % 3 == 0)
                    {
                        totalEnergy += winCount;
                    }
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {winCount} won battles and {totalEnergy} energy");
                    thereIsEnergy = false;
                    break;
                }                
            }
            if (thereIsEnergy == true)
            {
                Console.WriteLine($"Won battles: {winCount}. Energy left: {totalEnergy}");
            }            
        }
    }
}
