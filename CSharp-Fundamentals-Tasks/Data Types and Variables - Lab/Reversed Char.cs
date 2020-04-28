using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversed_Char
{
    class Program
    {
        static void Main(string[] args)
        {
            char character1 = char.Parse(Console.ReadLine());
            char character2 = char.Parse(Console.ReadLine());
            char character3 = char.Parse(Console.ReadLine());

            Console.WriteLine(character3 + " " + character2 + " " + character1);
        }
    }
}
