using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] participantList = Console.ReadLine()
                .Split(new string[] { ",", " " }, 
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string input = Console.ReadLine();

            Dictionary<string, int> dataBase = new Dictionary<string, int>();

            while (input != "end of race")
            {
                string extractText = Regex.Replace(input, @"[^A-Za-z]+", String.Empty);
                string extractDigits = Regex.Replace(input, @"[^0-9]+", String.Empty);
                char[] digitsChars = extractDigits.ToCharArray();
                int[] currDistance = Array.ConvertAll(digitsChars, c => (int)Char.GetNumericValue(c));

                if (participantList.Contains(extractText))
                {
                    if (!dataBase.ContainsKey(extractText))
                    {
                        dataBase.Add(extractText, currDistance.Sum());
                    }
                    else
                    {
                        dataBase[extractText] += currDistance.Sum();
                    }
                }
                input = Console.ReadLine();
            }
            
            int counter = 0;
            foreach (var item in dataBase.OrderByDescending(a => a.Value))
            {
                counter++;
                if (counter == 1)
                {
                    Console.WriteLine($"{counter}st place: {item.Key}");
                }
                else if (counter == 2)
                {
                    Console.WriteLine($"{counter}nd place: {item.Key}");
                }                
                else if (counter == 3)
                {
                    Console.WriteLine($"{counter}rd place: {item.Key}");
                }
                else
                {
                    break;
                }
            }
        }
    }
}
