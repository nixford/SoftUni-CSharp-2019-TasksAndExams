using System;
using System.Collections.Generic;
using System.Linq;

namespace Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberN = int.Parse(Console.ReadLine());

            int[,] matrix = new int[numberN, numberN];

            for (int row = 0; row < matrix.GetLongLength(0); row++)
            {
                int[] colElements = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sum += matrix[row,row];
            }
            Console.WriteLine(sum);
        }
    }
}
