using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> bomb = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int bombNumber = bomb[0];
            int bombPower = bomb[1];
            int index = numbersList.IndexOf(bombNumber);

            while (!index.Equals(-1))
            {
                List<int> range = new List<int>();
                if (index < bombPower)
                {
                    range.AddRange(numbersList.Take(numbersList.Count - (numbersList.Count - index) + bombPower + 1));
                    numbersList.RemoveRange(0, range.Count);
                }
                else
                {
                    range.AddRange(numbersList.Skip(index - bombPower).Take(2 * bombPower + 1));
                    numbersList.RemoveRange(index - bombPower, range.Count);
                }
                index = numbersList.IndexOf(bombNumber);
            }

            Console.WriteLine(numbersList.Sum());
        }
    }
}