using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Arriving_in_Kathmandu
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            string pattern = @"^(?<nameOfPeak>[A-Za-z\!\@\#\$\?0-9]+)=(?<geoCodeLength>[0-9]+)<<(?<geoCode>.*)$";

            while ((input = Console.ReadLine()) != "Last note")
            {
                Match matched = Regex.Match(input, pattern);

                if (Regex.IsMatch(input, pattern))
                {
                    string nameOfPeak = matched.Groups["nameOfPeak"].Value;
                    int length = int.Parse(matched.Groups["geoCodeLength"].Value);
                    string geoCode = matched.Groups["geoCode"].Value;

                    if (length == geoCode.Length)
                    {
                        string patternClearName = @"[\!\@\#\$\?]*";
                        string claerName = Regex.Replace(nameOfPeak, patternClearName, string.Empty);
                        Console.WriteLine($"Coordinates found! {claerName} -> {geoCode}");
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                    }                    
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }
            }
        }
    }
}
