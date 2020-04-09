using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()) + 'a';            
            
            for (char letter1 = 'a'; letter1 < n; letter1++)
            {
                for (char letter2 = 'a'; letter2 < n; letter2++)
                {
                    for (char letter3 = 'a'; letter3 < n; letter3++)
                    {
                        string text = "" + letter1 + letter2 + letter3;
                        Console.WriteLine(text);
                      
                    }                    
                }
            }
        }
    }
}
