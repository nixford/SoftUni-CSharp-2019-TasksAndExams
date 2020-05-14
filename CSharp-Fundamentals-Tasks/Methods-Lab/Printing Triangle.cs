using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            TopPart(input);
            BottomPart(input);
        }

        static void TopPart(int input)
        {
            for (int row = 1; row <= input; row++)
            {
                for (int col = 1; col <= row; col++)
                {
                    Console.Write(col + " ");
                }
                Console.WriteLine();
            }
        }

        static void BottomPart(int input)
        {
            for (int row = input; row >= 1; row--)
            {
                for (int col = 1; col < row; col++)
                {
                    Console.Write(col + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
