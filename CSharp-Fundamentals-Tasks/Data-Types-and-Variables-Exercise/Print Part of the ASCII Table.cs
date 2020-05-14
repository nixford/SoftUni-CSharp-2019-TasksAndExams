using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_Part_of_the_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int startIndex = int.Parse(Console.ReadLine());
            int endIndex = int.Parse(Console.ReadLine());

            for (int cyrrentIndex = startIndex; cyrrentIndex <= endIndex; cyrrentIndex++)
            {
                Console.Write((char)cyrrentIndex + " ");
            }
        }
    }
}
