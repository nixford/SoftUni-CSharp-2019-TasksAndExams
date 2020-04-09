using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine()
                .Split(new string[] { ",", " " }, 
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var ticket in tickets)
            {
                if (ticket.Length == 20)
                {
                    string leftHalf = string.Join("", ticket.Take(10).ToArray()); // Взима първите 10 символа
                    string rightHalf = string.Join("", ticket.Skip(10).Take(10).ToArray()); // пропуска първите 10 символа и взима следващите 10 символа

                    string pattern = @"([@|#|$|^])\1{5,9}";
                    if (Regex.IsMatch(leftHalf, pattern))
                    {
                        Match repeatLeft = Regex.Match(leftHalf, pattern);
                        string symbolsLeft = repeatLeft.Value;
                        char charLeft = symbolsLeft[0];
                        int lenghtLeft = repeatLeft.Value.Count();

                        Match repeatRight = Regex.Match(rightHalf, pattern);
                        string symbolsRight = repeatRight.Value;
                        char charRight = symbolsRight[0];
                        int lenghtRight = repeatRight.Value.Count();

                        int minLenght = Math.Min(lenghtLeft, lenghtRight);

                        if (minLenght >= 6 && charLeft == charRight)
                        {
                            if (lenghtRight == 10)
                            {
                                Console.WriteLine($"ticket \"{ ticket}\" - {minLenght}{charRight} Jackpot!");
                            }
                            else
                            {
                                Console.WriteLine($"ticket \"{ ticket}\" - {minLenght}{charRight}");
                            }
                        }
                        else
                        {                            
                            Console.WriteLine($"ticket \"{ticket}\" - no match");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }
                else
                {
                    Console.WriteLine("invalid ticket");
                }
            }            
        }
    }
}
