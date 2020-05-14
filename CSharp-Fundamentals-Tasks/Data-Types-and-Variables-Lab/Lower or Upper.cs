using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lower_or_Upper
{
    class Program
    {
        static void Main(string[] args)
        {
            char letter = char.Parse(Console.ReadLine());
            int letterNumber = (int)letter;
            string type = string.Empty;

            if (letterNumber >= 65 && letterNumber <= 90)
            {
                type = "upper-case";
            }
            else if (letterNumber >= 97 && letterNumber <= 122)
            {
                type = "lower-case";
            }
            Console.WriteLine(type);
        }
    }
}
