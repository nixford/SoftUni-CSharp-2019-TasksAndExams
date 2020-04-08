using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace The_Isle_of_Man_TT_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<surraundings>[\#|\$|\%|\*|\&])(?<nameOfRacer>[A-Za-z]+)\1=(?<number>[0-9]+)!!(?<encryptedGeoCode>.*)";

            while (true)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);
                if (Regex.IsMatch(input, pattern) == true)
                {                    
                    string raceName = match.Groups["nameOfRacer"].Value;
                    int codeLength = int.Parse(match.Groups["number"].Value);
                    string geoCode = match.Groups["encryptedGeoCode"].Value;
                    if (codeLength == geoCode.Length)
                    {
                        char[] decryptedCode = new char[geoCode.Length];
                        for (int i = 0; i < geoCode.Length; i++)
                        {
                            decryptedCode[i] = (char)(geoCode[i] + codeLength);
                        }
                        Console.WriteLine($"Coordinates found! {raceName} -> {string.Join("", decryptedCode)}");
                        break;
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
