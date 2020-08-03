using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int messageNumber = int.Parse(Console.ReadLine());
            string input = String.Empty;
            string lowerCase = String.Empty;
            int count = 0;
            StringBuilder temp = new StringBuilder();
            List<string> decriptedMessagesList = new List<string>();
            string pattern = @"[^@\-!:>]*\@(?<planet>[A-Za-z]+)[^@\-!:>]*\:(?<population>[0-9]+)[^@\-!:>]*!(?<attackType>A|D)![^@\-!:>]*->(?<solduresCount>[0-9]+)[^@\-!:>]*";
            List<string> attackTypeList = new List<string>();
            List<string> planetAttackList = new List<string>();

            List<string> destroedTypeList = new List<string>();
            List<string> planetDestroedList = new List<string>();


            for (int i = 0; i < messageNumber; i++)
            {
                input = Console.ReadLine();
                lowerCase = input.ToLower();
                for (int j = 0; j < input.Length; j++)
                {
                    if (lowerCase[j] == 's' || lowerCase[j] == 't' || lowerCase[j] == 'a' || lowerCase[j] == 'r')
                    {
                        count++;
                    }
                }
                for (int k = 0; k < input.Length; k++)
                {
                    int currChar = input[k];
                    int decriptedChar = currChar - count;
                    temp.Append((char)(decriptedChar));
                }
                count = 0;
                decriptedMessagesList.Add(temp.ToString());
                temp = new StringBuilder();
            }

            for (int i = 0; i < decriptedMessagesList.Count; i++)
            {
                string inputDecripted = decriptedMessagesList[i];
                Match match = Regex.Match(inputDecripted, pattern);
                string planet = match.Groups["planet"].Value;
                string type = match.Groups["attackType"].Value;

                if (type == "A")
                {                    
                    planetAttackList.Add(planet);
                }
                else if (type == "D")
                {
                    planetDestroedList.Add(planet);
                }               
            }

            planetAttackList.Sort();
            planetDestroedList.Sort();
            Console.WriteLine($"Attacked planets: {planetAttackList.Count}");
            for (int i = 0; i < planetAttackList.Count; i++)
            {
                Console.WriteLine($"-> {planetAttackList[i]}");
            }

            Console.WriteLine($"Destroyed planets: {planetDestroedList.Count}");
            for (int i = 0; i < planetDestroedList.Count; i++)
            {
                Console.WriteLine($"-> {planetDestroedList[i]}");
            }
        }
    }
}
