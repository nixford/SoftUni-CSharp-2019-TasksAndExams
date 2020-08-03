using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decrypting_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            byte key = byte.Parse(Console.ReadLine());
            byte n = byte.Parse(Console.ReadLine());
            char decryptedLetter = '\u0000';
            int fromLetterToNum = 0;
            string message = string.Empty;

            for (int cyrrentLetter = 1; cyrrentLetter <= n; cyrrentLetter++)
            {
                char letter = char.Parse(Console.ReadLine());
                fromLetterToNum = (int)letter;
                decryptedLetter = (char)(fromLetterToNum + key);
                message = message + decryptedLetter;
            }
            Console.WriteLine(message);
        }
    }
}
