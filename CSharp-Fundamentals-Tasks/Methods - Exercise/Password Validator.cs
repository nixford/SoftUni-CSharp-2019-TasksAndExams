using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();            
            bool passCharLength = PasswordLenght(password);
            bool passCharAndDigitsLength = PasswordLetterAndDigits(password);
            bool passTwoDigits = PasswordDigitCounter(password);

            if (passCharLength == true && passCharAndDigitsLength == true && passTwoDigits == true)
            {
                Console.WriteLine("Password is valid");
            }
            if (!passCharLength)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!passCharAndDigitsLength)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!passTwoDigits)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
        }

        private static bool PasswordLenght(string password)
        {
            bool isFromSixToTen = false;
            int charCounter = 0;
            foreach (var item in password)
            {
                charCounter++;
            }
            if (charCounter >= 6 && charCounter <= 10)
            {
                isFromSixToTen = true;
            }

            return isFromSixToTen;
        }

        private static bool PasswordDigitCounter(string password)
        {
            bool IsMoreThanTwo = false;
            int counter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]))
                {
                    counter++;
                }
            }
            if (counter >= 2)
            {
                IsMoreThanTwo = true;
            }
            return IsMoreThanTwo;
        }

        private static bool PasswordLetterAndDigits(string password)
        {
            bool IsLetterAndDigitOnly = true;
            for (int i = 0; i < password.Length; i++)
            {
                if (!(char.IsLetterOrDigit(password[i])))
                {
                    IsLetterAndDigitOnly = false;
                }
            }
            return IsLetterAndDigitOnly;
        }
    }
}
