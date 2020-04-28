using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            char[] thirdLine = Console.ReadLine().ToCharArray();

            int totalSum = 0;

            for (int i = 0; i < thirdLine.Length; i++)
            {
                int currCharASCIINumber = (int)thirdLine[i];
                if (currCharASCIINumber > (int)firstChar && currCharASCIINumber < (int)secondChar)
                {
                    totalSum = totalSum + currCharASCIINumber;
                }
            }
            Console.WriteLine(totalSum);
        }
    }
}
