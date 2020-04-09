using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().Trim().ToUpper();

            string patternText = @"\d";
            string patternNumbers = @"[^\d]";
            string[] text = Regex.Split(input, patternText);
            string[] numbers = Regex.Split(input, patternNumbers);
            int uniqueSumbol = 0;

            List<string> currText = new List<string>();
            List<int> currNumber = new List<int>();

            StringBuilder output = new StringBuilder();

            foreach (var item in text)
            {
                if (item != string.Empty)
                {
                    currText.Add(item.ToUpper());
                }
            }
            foreach (var item in numbers)
            {
                if (item != string.Empty)
                {
                    currNumber.Add(int.Parse(item));
                }
            }

            List<char> temp = new List<char>();
            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsDigit(input[i]) && !temp.Contains(input[i]))
                {
                    uniqueSumbol++;
                    temp.Add(input[i]);
                }
            }

            Console.WriteLine($"Unique symbols used: {uniqueSumbol}");
            for (int i = 0; i < currNumber.Count; i++)
            {
                for (int j = 0; j < currNumber[i]; j++)
                {
                    output.Append(currText[i]);
                }                
            }
            Console.WriteLine(output);
        }
    }
}
