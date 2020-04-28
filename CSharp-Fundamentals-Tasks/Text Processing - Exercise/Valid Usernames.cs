using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputLine = Console.ReadLine()
                .Split(new string[] { ", " }, 
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            StringBuilder validChars = new StringBuilder();
            List<string> validPasswordsList = new List<string>();

            foreach (var item in inputLine)
            {
                char[] currPasswords = item.ToCharArray();
                for (int i = 0; i < currPasswords.Length; i++)
                {
                    if (currPasswords.Length >= 3 && currPasswords.Length <= 16)
                    {
                        if (Char.IsLetterOrDigit(currPasswords[i]) ||
                            currPasswords[i] == '_' ||
                            currPasswords[i] == '-')
                        {
                            validChars.Append(currPasswords[i]);
                        }
                        else
                        {
                            validChars = new StringBuilder();
                            break;
                        }
                    }
                    else
                    {
                        validChars = new StringBuilder();
                        break;
                    }                    
                }
                if (validChars.ToString() != string.Empty)
                {
                    validPasswordsList.Add(validChars.ToString().TrimStart());
                }
                validChars = new StringBuilder();
            }
            foreach (var item in validPasswordsList)
            {
                Console.WriteLine(item.TrimStart());
            }
        }
    }
}
