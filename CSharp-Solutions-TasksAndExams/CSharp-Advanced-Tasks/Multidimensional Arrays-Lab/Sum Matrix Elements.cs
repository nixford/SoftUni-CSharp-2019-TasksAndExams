using System;
using System.ComponentModel;
using System.Linq;

namespace Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] colsAndRows = Console.ReadLine()
                .Split(new string[] { ", " },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = colsAndRows[0];
            int cols = colsAndRows[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLongLength(0); row++)
            {
                int[] collElements = Console.ReadLine()
                .Split(new string[] { ", " },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < matrix.GetLongLength(1); col++)
                {
                    matrix[row, col] = collElements[col];
                }
            }
            int sum = 0;

            foreach (var number in matrix)
            {
                sum += number;
            }
            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);           
        }
    }
}
