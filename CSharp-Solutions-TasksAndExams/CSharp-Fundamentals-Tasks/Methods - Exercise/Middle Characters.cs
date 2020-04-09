using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            GetOutput(text);
            Console.WriteLine(GetOutput(text));
        }

        static string GetOutput(string text)
        {
            string output = string.Empty;
            if (text.Length % 2 == 0)
            {
                for (int i = 1; i <= text.Length; i++)
                {
                    if (i == text.Length / 2)
                    {
                        output = output + text[i - 1];
                        output = output + text[i];
                    }
                   
                }
            }
            else
            {
                for (int i = 1; i <= text.Length; i++)
                {
                    if (i == text.Length / 2)
                    {                       
                        output = output + text[i];
                    }

                }
            }
            return output;
        }
    }
}
