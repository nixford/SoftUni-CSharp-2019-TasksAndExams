using System;
using System.Linq;

namespace Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersArr = Console.ReadLine()
                .Split(new[] { ",", " " },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();
            Console.WriteLine(numbersArr.Length);
            Console.WriteLine(numbersArr.Sum());
        }
    }
}
