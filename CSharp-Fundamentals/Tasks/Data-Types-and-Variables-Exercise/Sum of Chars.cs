using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            byte numberOfLetters = byte.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= numberOfLetters; i++)
            {
                char cyrrentLetter = char.Parse(Console.ReadLine());
                sum = sum + (int)cyrrentLetter;
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
