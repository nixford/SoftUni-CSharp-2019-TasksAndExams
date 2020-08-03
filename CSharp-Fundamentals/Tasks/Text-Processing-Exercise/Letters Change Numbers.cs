using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputLine = Console.ReadLine()
                .Split(new string[] { " " }, 
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            char letterBefore = ' ';
            double number = 0;
            char letterAfter = ' ';
            double currSum = 0;
            List<double> totalSum = new List<double>();            
            string temp = string.Empty;

            for (int i = 0; i < inputLine.Length; i++)
            {
                char[] currPart = inputLine[i].ToCharArray();
                letterBefore = currPart[0];
                for (int j = 1; j < currPart.Length - 1; j++)
                {
                   temp = temp + currPart[j];
                }                
                number = double.Parse(temp);
                letterAfter = currPart[currPart.Length - 1];
                temp = string.Empty;

                // LetterBefore - if it is upper or lowe case
                if (Char.IsUpper(letterBefore))
                {
                    int positionInAlphabet1 = char.ToUpper(letterBefore) - 64;
                    currSum = currSum + (number / positionInAlphabet1);
                }
                else if (Char.IsLower(letterBefore))
                {
                    int positionInAlphabet2 = char.ToUpper(letterBefore) - 64;
                    currSum = currSum + (number * positionInAlphabet2);
                }

                // LetterAfter - if it is upper or lower case
                if (Char.IsUpper(letterAfter))
                {
                    int positionInAlphabet3 = char.ToUpper(letterAfter) - 64;
                    currSum = currSum - positionInAlphabet3;
                }
                else if (Char.IsLower(letterAfter))
                {
                    int positionInAlphabet4 = char.ToUpper(letterAfter) - 64;
                    currSum = currSum + positionInAlphabet4;
                }
                totalSum.Add(currSum);
                currSum = 0;
            }            
            Console.WriteLine($"{totalSum.Sum():f2}");
        }
    }
}
