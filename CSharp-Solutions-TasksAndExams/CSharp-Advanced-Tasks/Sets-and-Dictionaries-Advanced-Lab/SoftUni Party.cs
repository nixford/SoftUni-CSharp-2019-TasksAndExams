using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> regularGuests = new HashSet<string>();
            HashSet<string> VIPGuests = new HashSet<string>();
            string pattern = @"^[\S|\s]{8}$";
                
            while (true)
            {
                string currGuest = Console.ReadLine();
                Match match = Regex.Match(currGuest, pattern);
                if (Regex.IsMatch(currGuest, pattern))
                {
                    if (!Char.IsDigit(currGuest[0]))
                    {
                        regularGuests.Add(currGuest);
                    }
                    else
                    {
                        VIPGuests.Add(currGuest);
                    }                    
                }               
                
                if (currGuest == "PARTY")
                {
                    string attending = string.Empty;
                    while ((attending = Console.ReadLine()) != "END")
                    {                        
                        if (regularGuests.Contains(attending))
                        {
                            regularGuests.Remove(attending);
                        }
                        if (VIPGuests.Contains(attending))
                        {
                            VIPGuests.Remove(attending);
                        }
                    }
                    break;
                }
            }
            Console.WriteLine(regularGuests.Count + VIPGuests.Count);
            foreach (var guest in VIPGuests)
            {
                Console.WriteLine(guest);
            }
            foreach (var guest in regularGuests)
            {
                Console.WriteLine(guest);
            }            
        }
    }
}
