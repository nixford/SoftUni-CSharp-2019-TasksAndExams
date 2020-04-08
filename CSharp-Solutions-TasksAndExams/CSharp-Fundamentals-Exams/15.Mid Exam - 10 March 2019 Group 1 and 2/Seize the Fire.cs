using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seize_the_Fire
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('#').Select(a => a.Trim()).ToArray();
            int water = int.Parse(Console.ReadLine());

            List<string> inputList = new List<string>();
            string fireType = string.Empty;
            int range = 0;
            int totalFire = 0;
            List<int> cellsNumber = new List<int>();
            double totalEffort = 0;

            for (int i = 0; i < input.Length; i++)
            {
                inputList = input[i].Split(' ', '=').ToList();
                fireType = inputList[0];
                range = int.Parse(inputList[3]);

                if ((fireType == "High") && (range >= 81 && range <= 125))
                {
                    if (water - range >= 0)
                    {
                        water = water - range;
                        cellsNumber.Add(range);
                        totalEffort = totalEffort + (range * 0.25);
                        totalFire = totalFire + range;
                    }                    
                }

                if ((fireType == "Medium") && (range >= 51 && range <= 80))
                {                    
                    if (water - range >= 0)
                    {
                        water = water - range;
                        cellsNumber.Add(range);
                        totalEffort = totalEffort + (range * 0.25);
                        totalFire = totalFire + range;
                    }                    
                }

                if ((fireType == "Low") && (range >= 1 && range <= 50))
                {
                    if (water - range >= 0)
                    {
                        water = water - range;
                        cellsNumber.Add(range);
                        totalEffort = totalEffort + (range * 0.25);
                        totalFire = totalFire + range;
                    }                   
                }
            }
            Console.WriteLine("Cells:");
            foreach (var item in cellsNumber)
            {                
                Console.WriteLine(" - " + item);
            }            
            Console.WriteLine($"Effort: {totalEffort:f2}");
            Console.WriteLine($"Total Fire: {totalFire}");
        }
    }
}
