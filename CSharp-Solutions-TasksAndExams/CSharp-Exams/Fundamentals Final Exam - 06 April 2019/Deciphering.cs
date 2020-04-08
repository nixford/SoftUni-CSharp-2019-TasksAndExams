using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            string input1 = Console.ReadLine();
            string[] input2 = Console.ReadLine().Split(' ').ToArray();

            string pattern = @"^(?<validInput>[d-z\{\}\,\|\#]*)$";
            List<char> decritedLetters = new List<char>();

            if (Regex.IsMatch(input1, pattern))
            {
                char[] charrArr = input1.ToCharArray();
                for (int i = 0; i < charrArr.Length; i++)
                {
                    decritedLetters.Add((char)(charrArr[i] - 3));                    
                }

                string decriptedMessage = string.Join("", decritedLetters);
                string firstSubstring = input2[0];
                string secondSubstring = input2[1];
                while (decriptedMessage.Contains(firstSubstring))
                {
                    decriptedMessage = decriptedMessage.Replace(firstSubstring, secondSubstring);
                }
                Console.WriteLine(decriptedMessage);
            }
            else
            {
                Console.WriteLine("This is not the book you are looking for.");
            }            
        }
    }
}
