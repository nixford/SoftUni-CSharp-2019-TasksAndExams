using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @" (?<user>\b[A-Za-z0-9]+[\.\-_]?[A-Za-z0-9]+\b)@(?<host>\b[A-Za-z]+[\-]?[\.]*[A-Za-z]+\.[A-Za-z]+[\-]?[\.]*[A-Za-z]+\b)";
            MatchCollection matchesCollection = Regex.Matches(input, pattern);
            foreach (var item in matchesCollection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
