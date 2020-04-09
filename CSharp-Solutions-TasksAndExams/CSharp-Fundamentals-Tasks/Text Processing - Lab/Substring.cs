using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine().ToLower();
            string tex = Console.ReadLine();

            int index = tex.IndexOf(key);

            while (index != -1)
            {                
                tex = tex.Remove(index, key.Length);
                index = tex.IndexOf(key);
            }
            Console.WriteLine(tex);
        }
    }
}
