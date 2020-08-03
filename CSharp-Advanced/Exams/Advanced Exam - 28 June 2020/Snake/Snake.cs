using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int snakeRow = 0;
            int snakeCol = 0;
            bool isOutside = false;
            int foodQuantity = 0;

            char[,] matrix = new char[n, n];

            GetMatrixFullAndSnakeCoordinates(ref snakeRow, ref snakeCol, matrix);

            while (foodQuantity < 10)
            {
                string command = Console.ReadLine();

                if (command == "up")
                {
                    if (snakeRow - 1 < 0)
                    {
                        isOutside = true;
                        matrix[snakeRow, snakeCol] = '.';
                        break;
                    }
                    else
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        snakeRow--;
                        if (matrix[snakeRow, snakeCol] == '*')
                        {
                            foodQuantity++;
                            if (foodQuantity >= 10)
                            {
                                matrix[snakeRow, snakeCol] = 'S';
                                break;
                            }
                            matrix[snakeRow, snakeCol] = '.';
                        }

                        if (matrix[snakeRow, snakeCol] == '-')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                        }

                        if (matrix[snakeRow, snakeCol] == 'B')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            GetLairMove(ref snakeRow, ref snakeCol, matrix);
                            matrix[snakeRow, snakeCol] = '.';
                        }
                    }
                }
                else if (command == "down")
                {
                    if (snakeRow + 1 >= matrix.GetLength(1))
                    {
                        isOutside = true;
                        matrix[snakeRow, snakeCol] = '.';
                        break;
                    }
                    else
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        snakeRow++;
                        if (matrix[snakeRow, snakeCol] == '*')
                        {
                            foodQuantity++;
                            if (foodQuantity >= 10)
                            {
                                matrix[snakeRow, snakeCol] = 'S';
                                break;
                            }
                            matrix[snakeRow, snakeCol] = '.';
                        }

                        if (matrix[snakeRow, snakeCol] == '-')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                        }

                        if (matrix[snakeRow, snakeCol] == 'B')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            GetLairMove(ref snakeRow, ref snakeCol, matrix);
                            matrix[snakeRow, snakeCol] = '.';
                        }
                    }
                }
                else if (command == "left")
                {
                    matrix[snakeRow, snakeCol] = '.';
                    if (snakeCol - 1 < 0)
                    {
                        isOutside = true;
                        break;
                    }
                    else
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        snakeCol--;
                        if (matrix[snakeRow, snakeCol] == '*')
                        {
                            foodQuantity++;
                            if (foodQuantity >= 10)
                            {
                                matrix[snakeRow, snakeCol] = 'S';
                                break;
                            }
                        }

                        if (matrix[snakeRow, snakeCol] == '-')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                        }

                        if (matrix[snakeRow, snakeCol] == 'B')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            GetLairMove(ref snakeRow, ref snakeCol, matrix);
                            matrix[snakeRow, snakeCol] = '.';
                        }
                    }
                }
                else if (command == "right")
                {
                    matrix[snakeRow, snakeCol] = '.';
                    if (snakeCol + 1 >= matrix.GetLength(1))
                    {
                        isOutside = true;
                        break;
                    }
                    else
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        snakeCol++;
                        if (matrix[snakeRow, snakeCol] == '*')
                        {
                            foodQuantity++;
                            if (foodQuantity >= 10)
                            {
                                matrix[snakeRow, snakeCol] = 'S';
                                break;
                            }
                        }

                        if (matrix[snakeRow, snakeCol] == '-')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                        }

                        if (matrix[snakeRow, snakeCol] == 'B')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            GetLairMove(ref snakeRow, ref snakeCol, matrix);
                            matrix[snakeRow, snakeCol] = '.';
                        }
                    }
                }
            }

            if (isOutside == true)
            {
                Console.WriteLine("Game over!");
            }
            else
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodQuantity}");
            PrintMatrix(matrix);
        }
        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char currChar = matrix[row, col];
                    Console.Write(currChar);
                }
                Console.WriteLine();
            }
        }

        private static void GetLairMove(ref int snakeRow, ref int snakeCol, char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }
        }

        private static void GetMatrixFullAndSnakeCoordinates(ref int snakeRow, ref int snakeCol, char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = (char)currRow[col];
                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }
        }
    }
}
