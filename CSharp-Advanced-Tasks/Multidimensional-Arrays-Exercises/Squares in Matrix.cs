using System;
using System.Linq;

namespace Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowColNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int rows = rowColNumbers[0];
            int cols = rowColNumbers[1];
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] colElements = Console.ReadLine()
                    .Split()                    
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            int matchesCounts = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] && 
                        matrix[row + 1, col] == matrix[row + 1, col + 1] &&
                        matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        matchesCounts++;
                    }   
                }
            }
            Console.WriteLine(matchesCounts);
        }
    }
}
