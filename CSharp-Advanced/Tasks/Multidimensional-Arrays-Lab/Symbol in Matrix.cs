using System;
using System.Linq;

namespace Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowColNumber = int.Parse(Console.ReadLine());

            char[,] matrix = new char[rowColNumber, rowColNumber];
            bool match = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] colElements = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            char matchSymbol = char.Parse(Console.ReadLine());
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == matchSymbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        match = true;
                        break;
                    }
                }
                if (match == true)
                {
                    break;
                }
            }

            if (match == false)
            {
                Console.WriteLine($"{matchSymbol} does not occur in the matrix");
            }
        }
    }
}
