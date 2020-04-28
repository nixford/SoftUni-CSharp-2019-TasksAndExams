using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayer = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> secondPlayer = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int SumFirst = firstPlayer.Sum();
            int SumSecond = secondPlayer.Sum();

            while (SumFirst > 0 && SumSecond > 0)
            {
                if (firstPlayer[0] == secondPlayer[0])
                {
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                }
                else if (firstPlayer[0] > secondPlayer[0])
                {
                    int firstPlayerDeck = firstPlayer[0];
                    int secondPlayerDeck = secondPlayer[0];
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                    firstPlayer.Add(firstPlayerDeck);
                    firstPlayer.Add(secondPlayerDeck);                    
                }
                else
                {
                    int secondPlayerDeck = secondPlayer[0];
                    int firstPlayerDeck = firstPlayer[0];
                    secondPlayer.RemoveAt(0);
                    firstPlayer.RemoveAt(0);
                    secondPlayer.Add(secondPlayerDeck);
                    secondPlayer.Add(firstPlayerDeck);                   
                }
                SumFirst = firstPlayer.Sum();
                SumSecond = secondPlayer.Sum();
            }
            if (SumFirst < SumSecond)
            {
                Console.WriteLine($"Second player wins! Sum: {SumSecond}");
            }
            else
            {
                Console.WriteLine($"First player wins! Sum: {SumFirst}");
            }
        }
    }
}
