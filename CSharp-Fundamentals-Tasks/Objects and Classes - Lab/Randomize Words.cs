using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrayWords = Console.ReadLine().Split().ToArray();
            Random rnd = new Random();

            for (int pos1 = 0; pos1 < arrayWords.Length; pos1++)
            {
                int pos2 = rnd.Next(0, arrayWords.Length);
                if (pos1 != pos2)
                {
                    var old = arrayWords[pos1];
                    arrayWords[pos1] = arrayWords[pos2];
                    arrayWords[pos2] = old;
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, arrayWords));
        }
    }
}
