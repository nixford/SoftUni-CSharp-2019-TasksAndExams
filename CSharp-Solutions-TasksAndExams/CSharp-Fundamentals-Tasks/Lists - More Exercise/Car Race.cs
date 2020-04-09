using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            double sumLeftPlayer = 0;
            double sumRightPlayer = 0;            

            // Left player
            for (int i = 0; i < inputList.Count / 2; i++)
            {
                sumLeftPlayer = sumLeftPlayer + inputList[i];
                if (inputList[i] == 0)
                {
                    sumLeftPlayer = Math.Round(sumLeftPlayer * 0.8, 1);
                }
            }

            // Right player
            for (int i = inputList.Count - 1; i >= (inputList.Count / 2) + 1; i--)
            {
                sumRightPlayer = sumRightPlayer + inputList[i];
                if (inputList[i] == 0)
                {
                    sumRightPlayer = Math.Round(sumRightPlayer * 0.8, 1);
                }
            }

            if (sumLeftPlayer < sumRightPlayer)
            {
                Console.WriteLine($"The winner is left with total time: {sumLeftPlayer:F1}");
            }
            else
            {
                Console.WriteLine($"The winner is left with total time: {sumRightPlayer:F1}");
            }
        }
    }
}
