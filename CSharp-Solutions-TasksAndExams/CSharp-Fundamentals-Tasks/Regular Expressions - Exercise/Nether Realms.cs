using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace TryOut
{
    class NetherRealms
    {
        static void Main(string[] args)
        {
            var inputDemons = Regex.Split(Console.ReadLine(), @"\s*,\s*");

            foreach (string demon in inputDemons.OrderBy(x => x))
            {
                Console.WriteLine($"{demon} - {CalculateDemonhealth(demon)} health, {CalculateDemonDamage(demon):F2} damage");
            }
        }

        public static decimal CalculateDemonDamage(string demon)
        {
            decimal damage = 0;
            string digit = @"[-+]?((\d+\.\d+)|\d+)";
            MatchCollection digits = Regex.Matches(demon, digit);

            foreach (var element in digits)
            {
                damage += decimal.Parse(element.ToString());
            }

            int powering = demon.Count(x => x == '*');
            int weakening = demon.Count(x => x == '/');

            if (powering > 0)
            {
                damage *= (decimal)Math.Pow(2, powering);
            }

            if (weakening > 0)
            {
                damage /= (decimal)Math.Pow(2, weakening);
            }

            return damage;
        }

        public static long CalculateDemonhealth(string demon)
        {
            long health = 0;
            char[] demonToChars = demon.ToCharArray();
            char[] specialChars = new char[] { '-', '+', '*', '/', '.' };

            for (int i = 0; i < demonToChars.Length; i++)
            {
                if (!char.IsDigit(demonToChars[i]) && !specialChars.Contains(demonToChars[i]))
                {
                    health += demonToChars[i];
                }
            }
            return health;
        }
    }
}