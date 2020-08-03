using System;
using System.Linq;

namespace Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int squireSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[squireSize, squireSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colElements = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            int firstSum = 0;
            int secondSum = 0;           

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                firstSum += matrix[row, row];
                secondSum += matrix[row, --squireSize];
            }
            
            Console.WriteLine(Math.Abs(firstSum - secondSum));
        }
    }
}
