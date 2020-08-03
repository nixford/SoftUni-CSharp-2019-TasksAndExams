using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfLetters = int.Parse(Console.ReadLine());
            string word = string.Empty;
            for (int i = 1; i <= countOfLetters; i++)
            {
                string currentDigit = Console.ReadLine(); //44
                int mainDigit = int.Parse(currentDigit[0].ToString());
                if (mainDigit == 8 || mainDigit == 9)
                {
                    int offset = ((mainDigit - 2) * 3) + 1;
                    int offsetInSquare = currentDigit.Length;
                    int totalOffset = offset + offsetInSquare - 1;
                    char letter = (char)(97 + totalOffset);
                    word += letter;
                }
                else if (mainDigit == 0)
                {
                    word += ' ';
                }
                else
                {
                    int offset = (mainDigit - 2) * 3;
                    int offsetInSquare = currentDigit.Length;
                    int totalOffset = offset + offsetInSquare - 1;
                    char letter = (char)(97 + totalOffset);
                    word += letter;
                }
            }
            Console.WriteLine(word);
        }
    }
}
    

