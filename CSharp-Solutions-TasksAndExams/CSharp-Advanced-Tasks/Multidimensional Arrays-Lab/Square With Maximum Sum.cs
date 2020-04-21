using System;
using System.Linq;
using System.Numerics;

namespace Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowColNumber = Console.ReadLine()
                .Split(new string[] { ", " }, 
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[rowColNumber[0], rowColNumber[1]];
            int maxNum1 = 0;
            int maxNum2 = 0;
            int maxNum3 = 0;
            int maxNum4 = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colElement = Console.ReadLine()
                    .Split(new string[] { ", " }, 
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElement[col];
                }
            }

            int squireSum = 0;
            int maxSum = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    squireSum = matrix[row, col] + 
                        matrix[row, col + 1] + 
                        matrix[row + 1, col] + 
                        matrix[row + 1, col + 1];

                    if (squireSum > maxSum)
                    {
                        maxSum = squireSum;
                        maxNum1 = matrix[row, col];
                        maxNum2 = matrix[row, col + 1];
                        maxNum3 = matrix[row + 1, col];
                        maxNum4 = matrix[row + 1, col + 1];
                    }
                }
            }
            Console.Write(maxNum1 + " ");
            Console.Write(maxNum2);
            Console.WriteLine();
            Console.Write(maxNum3 + " ");
            Console.Write(maxNum4);
            Console.WriteLine();
            Console.WriteLine(maxSum);
        }
    }
}
