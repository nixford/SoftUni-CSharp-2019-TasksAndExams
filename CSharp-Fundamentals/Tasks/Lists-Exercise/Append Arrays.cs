using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Append_Arrays
{
    class Program
    {
        static void Main(string[] args)

        {
            string inputList = Console.ReadLine();
            char[] characters = inputList.ToCharArray();
            List<string> output = new List<string>();
            string currArr = String.Empty;

            for (int i = 0; i < characters.Length; i++)
            {
                if (characters[i] != ' ')
                {
                    if (characters[i] != '|')
                    {
                        currArr = currArr + characters[i].ToString();
                    }
                    else
                    {
                        output.Insert(0, currArr);
                        currArr = String.Empty;
                    }                    
                }                
            }
            output.Insert(0, currArr);
            string numbers = string.Empty;
            for (int i = 0; i < output.Count; i++)
            {
                numbers = numbers + output[i];
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }           
        }
    }
}
