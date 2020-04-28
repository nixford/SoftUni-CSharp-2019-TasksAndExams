using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string reversedText = string.Empty;

            for (int i = text.Length - 1; i >= 0; i--)
            {
                char symbol = text[i];
                reversedText = reversedText + symbol;                
            }
            Console.WriteLine(reversedText);
        }
    }
}
