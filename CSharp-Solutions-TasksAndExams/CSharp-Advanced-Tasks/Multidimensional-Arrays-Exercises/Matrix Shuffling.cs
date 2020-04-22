using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] lines = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = lines[col];
                }
            }

            string commands = string.Empty;

            while ((commands = Console.ReadLine()) != "END")
            {
                string[] commandList = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (commandList[0] == "swap" && commandList.Length == 5)
                {
                    int row1 = int.Parse(commandList[1]);
                    int col1 = int.Parse(commandList[2]);
                    int row2 = int.Parse(commandList[3]);
                    int col2 = int.Parse(commandList[4]);

                    if ((row1 >= 0 && row1 <= rows - 1) && 
                        (col1 >= 0 && col1 <= cols - 1) && 
                        (row2 >= 0 && row2 <= rows - 1) && 
                        (col2 >= 0 && col2 <= cols - 1))
                    {
                        var temp = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = temp;

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write($"{matrix[row, col]} ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid input!");
                }
            }
        }
    }
}
