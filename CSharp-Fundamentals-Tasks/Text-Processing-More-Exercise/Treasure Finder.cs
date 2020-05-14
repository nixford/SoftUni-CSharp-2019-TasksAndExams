using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            string input = Console.ReadLine();

            char[] currChars = new char[input.Length];
            int result = 0;
            StringBuilder temp = new StringBuilder();
            int count = 0;

            while (input != "find")
            {
                currChars = input.ToCharArray();
                for (int i = 0; i < currChars.Length; i++)
                {
                    if (count < numbers.Length)
                    {
                        result = (int)currChars[i] - numbers[count];
                        temp.Append((char)result);
                        count++;
                    }
                    else
                    {
                        count = 0;
                        result = (int)currChars[i] - numbers[count];
                        temp.Append((char)result);
                        count++;
                    }
                }
                count = 0;
                int typeStartIndex = temp.ToString().IndexOf('&');
                int typeEndIndex = temp.ToString().LastIndexOf('&');
                string treasureType = temp.ToString().Substring(typeStartIndex + 1, typeEndIndex - typeStartIndex - 1);
                int coordinatesStartIndex = temp.ToString().IndexOf('<');
                int coordinatesEndIndex = temp.ToString().LastIndexOf('>');
                string coordinates = temp.ToString().Substring(coordinatesStartIndex + 1, coordinatesEndIndex - coordinatesStartIndex - 1);
                Console.WriteLine($"Found {treasureType} at {coordinates}");
                temp = new StringBuilder();
                input = Console.ReadLine();
            } 
        }
    }
}
