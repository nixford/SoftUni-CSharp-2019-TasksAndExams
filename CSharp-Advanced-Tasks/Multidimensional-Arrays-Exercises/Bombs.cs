using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;

namespace Bombs
{
    class Bombs
    {
        static void Main(string[] args)
        {
            int dimentions = int.Parse(Console.ReadLine());

            int[,] matrix = new int[dimentions, dimentions];
            List<int> coordinates = new List<int>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colElements = Console.ReadLine()
                    .Split(new string[] { " " }, 
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }
            coordinates = Console.ReadLine()
                .Split(new[] { ","," " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < coordinates.Count - 1; i += 2)
            {
                int currRowCoordinate = coordinates[i];
                int currColCoordinate = coordinates[i + 1];

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(0); col++)
                    {
                        if (row == currRowCoordinate && col == currColCoordinate)
                        {
                            // Around the bomd there is at least one cell from top, bottom, right and left
                            if ((row - 1 >= 0 && col - 1 >= 0) &&
                                (row + 1 < matrix.GetLength(0) && col + 1 < matrix.GetLength(0)) &&
                                matrix[row, col] > 0)
                            {
                                if (matrix[row - 1, col - 1] > 0)
                                {
                                    matrix[row - 1, col - 1] = matrix[row - 1, col - 1] - matrix[row, col]; // top left diagonal
                                }
                                if (matrix[row - 1, col] > 0)
                                {
                                    matrix[row - 1, col] = matrix[row - 1, col] - matrix[row, col]; // top
                                }
                                if (matrix[row - 1, col + 1] > 0)
                                {
                                    matrix[row - 1, col + 1] = matrix[row - 1, col + 1] - matrix[row, col]; // top rigth diagonal
                                }
                                if (matrix[row, col - 1] > 0)
                                {
                                    matrix[row, col - 1] = matrix[row, col - 1] - matrix[row, col]; // left
                                }
                                if (matrix[row, col + 1] > 0)
                                {
                                    matrix[row, col + 1] = matrix[row, col + 1] - matrix[row, col]; // right
                                }
                                if (matrix[row + 1, col - 1] > 0)
                                {
                                    matrix[row + 1, col - 1] = matrix[row + 1, col - 1] - matrix[row, col]; // bottom left diagonal
                                }
                                if (matrix[row + 1, col] > 0)
                                {
                                    matrix[row + 1, col] = matrix[row + 1, col] - matrix[row, col]; // bottom
                                }
                                if (matrix[row + 1, col + 1] > 0)
                                {
                                    matrix[row + 1, col + 1] = matrix[row + 1, col + 1] - matrix[row, col]; // bottom right diagonal
                                }                          
                                matrix[row, col] = 0;
                            }
                            // the bomb is in top left corner
                            else if ((row == 0 && col == 0) && matrix[row, col] > 0)
                            {
                                if (matrix[row, col + 1] > 0)
                                {
                                    matrix[row, col + 1] = matrix[row, col + 1] - matrix[row, col]; // right
                                }
                                if (matrix[row + 1, col + 1] > 0)
                                {
                                    matrix[row + 1, col + 1] = matrix[row + 1, col + 1] - matrix[row, col]; // bottom right diagonal
                                }
                                if (matrix[row + 1, col] > 0)
                                {
                                    matrix[row + 1, col] = matrix[row + 1, col] - matrix[row, col]; // bottom
                                }                    
                                matrix[row, col] = 0;
                            }
                            // the bomb is in top right corner
                            else if ((row == 0 && col == matrix.GetLength(1) - 1) && matrix[row, col] > 0)
                            {
                                if (matrix[row, col - 1] > 0)
                                {
                                    matrix[row, col - 1] = matrix[row, col - 1] - matrix[row, col]; // left
                                }
                                if (matrix[row + 1, col - 1] > 0)
                                {
                                    matrix[row + 1, col - 1] = matrix[row + 1, col - 1] - matrix[row, col]; // bottom left diagonal
                                }
                                if (matrix[row + 1, col] > 0)
                                {
                                    matrix[row + 1, col] = matrix[row + 1, col] - matrix[row, col]; // bottom
                                }                     
                                matrix[row, col] = 0;
                            }
                            // the bomb is in bottom left corner
                            else if ((row == matrix.GetLength(0) - 1 && col == 0) && matrix[row, col] > 0)
                            {
                                if (matrix[row - 1, col] > 0)
                                {
                                    matrix[row - 1, col] = matrix[row - 1, col] - matrix[row, col]; // top
                                }
                                if (matrix[row - 1, col + 1] > 0)
                                {
                                    matrix[row - 1, col + 1] = matrix[row - 1, col + 1] - matrix[row, col]; // top right diagonal
                                }
                                if (matrix[row, col + 1] > 0)
                                {
                                    matrix[row, col + 1] = matrix[row, col + 1] - matrix[row, col]; // left
                                }                      
                                matrix[row, col] = 0;
                            }
                            // the bomb is in bottom right corner
                            else if ((row == matrix.GetLength(0) - 1 && col == matrix.GetLength(1) - 1) && matrix[row, col] > 0)
                            {
                                if (matrix[row - 1, col] > 0)
                                {
                                    matrix[row - 1, col] = matrix[row - 1, col] - matrix[row, col]; // top
                                }
                                if (matrix[row - 1, col - 1] > 0)
                                {
                                    matrix[row - 1, col - 1] = matrix[row - 1, col - 1] - matrix[row, col]; // top left diagonal
                                }
                                if (matrix[row, col - 1] > 0)
                                {
                                    matrix[row, col - 1] = matrix[row, col - 1] - matrix[row, col]; // left
                                }                       
                                matrix[row, col] = 0;
                            }
                            // the bomb is on left side = 0 col between top left and bottom left corner
                            else if ((row > 0 && row < matrix.GetLength(0) - 1 && col == 0) && matrix[row, col] > 0)
                            {
                                if (matrix[row - 1, col] > 0)
                                {
                                    matrix[row - 1, col] = matrix[row - 1, col] - matrix[row, col]; // top
                                }
                                if (matrix[row - 1, col + 1] > 0)
                                {
                                    matrix[row - 1, col + 1] = matrix[row - 1, col + 1] - matrix[row, col]; // top right diagonal
                                }
                                if (matrix[row, col + 1] > 0)
                                {
                                    matrix[row, col + 1] = matrix[row, col + 1] - matrix[row, col]; // right
                                }
                                if (matrix[row + 1, col + 1] > 0)
                                {
                                    matrix[row + 1, col + 1] = matrix[row + 1, col + 1] - matrix[row, col]; // bottom right diagonal
                                }
                                if (matrix[row + 1, col] > 0)
                                {
                                    matrix[row + 1, col] = matrix[row + 1, col] - matrix[row, col]; // bottom
                                }                   
                                matrix[row, col] = 0;
                            }
                            // the bomb is on right side = max col between top right and bottom right corner
                            else if ((row > 0 && row < matrix.GetLength(0) - 1 && col == matrix.GetLength(1) - 1) && matrix[row, col] > 0)
                            {
                                if (matrix[row - 1, col] > 0)
                                {
                                    matrix[row - 1, col] = matrix[row - 1, col] - matrix[row, col]; // top
                                }
                                if (matrix[row - 1, col - 1] > 0)
                                {
                                    matrix[row - 1, col - 1] = matrix[row - 1, col - 1] - matrix[row, col]; // top left diagonal
                                }
                                if (matrix[row, col - 1] > 0)
                                {
                                    matrix[row, col - 1] = matrix[row, col - 1] - matrix[row, col]; // left
                                }
                                if (matrix[row + 1, col - 1] > 0)
                                {
                                    matrix[row + 1, col - 1] = matrix[row + 1, col - 1] - matrix[row, col]; // bottom left diagonal
                                }
                                if (matrix[row + 1, col] > 0)
                                {
                                    matrix[row + 1, col] = matrix[row + 1, col] - matrix[row, col]; // bottom
                                }                                        
                                matrix[row, col] = 0;
                            }
                            // the bomb is on top side = 0 col between top left and top right corner
                            else if ((row == 0 && col > 0 && col < matrix.GetLength(1) - 1) && matrix[row, col] > 0)
                            {
                                if (matrix[row, col - 1] > 0)
                                {
                                    matrix[row, col - 1] = matrix[row, col - 1] - matrix[row, col]; // left
                                }
                                if (matrix[row + 1, col - 1] > 0)
                                {
                                    matrix[row + 1, col - 1] = matrix[row + 1, col - 1] - matrix[row, col]; // bottom left diagonal
                                }
                                if (matrix[row + 1, col] > 0)
                                {
                                    matrix[row + 1, col] = matrix[row + 1, col] - matrix[row, col]; // bottom
                                }
                                if (matrix[row + 1, col + 1] > 0)
                                {
                                    matrix[row + 1, col + 1] = matrix[row + 1, col + 1] - matrix[row, col]; // bottom right diagonal
                                }
                                if (matrix[row, col + 1] > 0)
                                {
                                    matrix[row, col + 1] = matrix[row, col + 1] - matrix[row, col]; // right
                                }                       
                                matrix[row, col] = 0;
                            }
                            // the bomb is on bottom side = max row between bottom left and bottom right corner
                            else if ((row == 0 && col > 0 && col < matrix.GetLength(1) - 1) && matrix[row, col] > 0)
                            {
                                if (matrix[row, col - 1] > 0)
                                {
                                    matrix[row, col - 1] = matrix[row, col - 1] - matrix[row, col]; // left
                                }
                                if (matrix[row - 1, col - 1] > 0)
                                {
                                    matrix[row - 1, col - 1] = matrix[row - 1, col - 1] - matrix[row, col]; // top left diagonal
                                }
                                if (matrix[row - 1, col] > 0)
                                {
                                    matrix[row - 1, col] = matrix[row - 1, col] - matrix[row, col]; // top
                                }
                                if (matrix[row - 1, col + 1] > 0)
                                {
                                    matrix[row - 1, col + 1] = matrix[row - 1, col + 1] - matrix[row, col]; // top right diagonal 
                                }
                                if (matrix[row, col + 1] > 0)
                                {
                                    matrix[row, col + 1] = matrix[row, col + 1] - matrix[row, col]; // right
                                }                    
                                matrix[row, col] = 0;
                            }
                        }
                    }
                }
            }            

            int counter = 0;
            int sum = 0;
            foreach (var item in matrix)
            {
                if (item > 0)
                {
                    counter++;
                    sum += item;
                }
            }
            Console.WriteLine($"Alive cells: {counter}");
            Console.WriteLine($"Sum: {sum}");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
