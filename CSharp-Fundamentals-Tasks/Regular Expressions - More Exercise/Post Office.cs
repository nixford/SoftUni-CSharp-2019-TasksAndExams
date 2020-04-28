using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Post_Office
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new string[] { "|" }, 
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            // Finding first part - capital letters
            string capitalLetterPattern = @"(\$|\#|\%|\*|\&)[A-Z]+\1";
            Match matchCapLetters = Regex.Match(input[0], capitalLetterPattern);
            string textCapLetters = matchCapLetters.ToString();
            char[] firstPartChars = textCapLetters
                .Skip(1)
                .Take(textCapLetters.Length - 2)
                .ToArray();

            // Finding second part - first letters and word's lenght in numbers
            string numbersMatchPattern = @"(\d{2})\:(\d{2})";
            MatchCollection matchesNumbersCollection = Regex.Matches(input[1], numbersMatchPattern);            
            List<int> secondPartNumbers = new List<int>();
            List<char> letterList = new List<char>();
            List<int> lenghtWord = new List<int>();
            foreach (var item in matchesNumbersCollection)
            {
                string[] temp1 = item.ToString().Split(':');
                secondPartNumbers.Add(int.Parse(temp1[0]));
                secondPartNumbers.Add(int.Parse(temp1[1]));
            }

            int count = 0;
            for (int i = 0; i < secondPartNumbers.Count; i+=2)
            {
                if (secondPartNumbers[i] == (int)firstPartChars[count])
                {
                    letterList.Add(firstPartChars[count]);
                    lenghtWord.Add(secondPartNumbers[i + 1]);
                    count++;
                }                
            }

            // Finding words determined by first letter and word's lenght
            string[] thirdPart = input[2]
                .Split(new string[] { " " }, 
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            for (int i = 0; i < thirdPart.Length; i++)
            {
                string currWord = thirdPart[i];
                for (int j = 0; j < letterList.Count; j++)
                {
                    if (currWord[0] == letterList[j] && currWord.Length == lenghtWord[j] + 1)
                    {
                        Console.WriteLine(currWord);
                    }
                }
            }
        }
    }
}
