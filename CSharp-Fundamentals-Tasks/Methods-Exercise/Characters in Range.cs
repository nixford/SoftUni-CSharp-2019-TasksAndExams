using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            GetCharacters(first, second);
        }

        static void GetCharacters(char first, char second)
        {
            int numberInTableFirst = (int)first;
            int numberInTableSecond = (int)second;

            if (first < second)
            {
                for (int i = first + 1; i < second; i++)
                {
                    Console.Write((char)i + " ");
                }
                Console.WriteLine();
            }
            else
            {
                for (int i = second + 1; i < first; i++)
                {
                    Console.Write((char)i + " ");
                }
                Console.WriteLine();
            }     
        }
    }
}
