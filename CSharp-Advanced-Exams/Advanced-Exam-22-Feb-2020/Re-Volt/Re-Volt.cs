using System;
using System.Linq;

namespace Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            int countOfCommands = int.Parse(Console.ReadLine());

            int playerRow = 0;
            int playerCol = 0;
            bool isWinning = false;

            char[,] matrix = new char[n,n];

            GetMatrixFullAndPlayerCoordinates(ref playerRow, ref playerCol, matrix);

            string command = string.Empty;
            while (countOfCommands > 0)
            {
                command = Console.ReadLine();

                if (command == "up")
                {
                    if (matrix[playerRow, playerCol] == 'f')
                    {
                        matrix[playerRow, playerCol] = '-';
                    }
                    int initialPlayerRow = playerRow;
                    
                    playerRow = MoveAndCheckForUpBorder(playerRow, matrix);                   

                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        matrix[playerRow, playerCol] = 'f';
                        isWinning = true;
                        break;
                    }
                    else if (matrix[playerRow, playerCol] == 'B')
                    {
                        playerRow = MoveAndCheckForUpBorder(playerRow, matrix);

                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            matrix[playerRow, playerCol] = 'f';
                            isWinning = true;
                            break;
                        }
                    }
                    else if (matrix[playerRow, playerCol] == 'T')
                    {
                        playerRow = initialPlayerRow;
                    }

                }
                else if (command == "down")
                {
                    if (matrix[playerRow, playerCol] == 'f')
                    {
                        matrix[playerRow, playerCol] = '-';
                    }
                    int initialPlayerRow = playerRow;
                    playerRow = MoveAndCheckDownBorder(playerRow, matrix);

                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        matrix[playerRow, playerCol] = 'f';
                        isWinning = true;
                        break;
                    }
                    else if (matrix[playerRow, playerCol] == 'B')
                    {
                        playerRow = MoveAndCheckDownBorder(playerRow, matrix);

                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            matrix[playerRow, playerCol] = 'f';
                            isWinning = true;
                            break;
                        }
                    }
                    else if (matrix[playerRow, playerCol] == 'T')
                    {
                        playerRow = initialPlayerRow;
                    }
                }
                else if (command == "left")
                {
                    if (matrix[playerRow, playerCol] == 'f')
                    {
                        matrix[playerRow, playerCol] = '-';
                    }
                    int initialPlayerCol = playerCol;
                    playerCol = MoveAndCheckForLeftBorder(playerCol, matrix);

                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        matrix[playerRow, playerCol] = 'f';
                        isWinning = true;
                        break;
                    }
                    else if (matrix[playerRow, playerCol] == 'B')
                    {
                        playerCol = MoveAndCheckForLeftBorder(playerCol, matrix);
                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            matrix[playerRow, playerCol] = 'f';
                            isWinning = true;
                            break;
                        }
                    }
                    else if (matrix[playerRow, playerCol] == 'T')
                    {
                        playerCol = initialPlayerCol;
                    }
                }
                else if (command == "right")
                {
                    if (matrix[playerRow, playerCol] == 'f')
                    {
                        matrix[playerRow, playerCol] = '-';
                    }
                    int initialPlayerCol = playerCol;
                    playerCol = MoveAndCheckForRightBorder(playerCol, matrix);

                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        matrix[playerRow, playerCol] = 'f';
                        isWinning = true;
                        break;
                    }
                    else if (matrix[playerRow, playerCol] == 'B')
                    {
                        playerCol = MoveAndCheckForRightBorder(playerCol, matrix);
                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            matrix[playerRow, playerCol] = 'f';
                            isWinning = true;
                            break;
                        }
                    }
                    else if (matrix[playerRow, playerCol] == 'T')
                    {
                        playerCol = initialPlayerCol;
                    }
                }

                countOfCommands--;
            }
            matrix[playerRow, playerCol] = 'f';

            if (isWinning)
            {
                Console.WriteLine("Player won!");
                PrintMatrix(matrix);
            }
            else
            {
                Console.WriteLine("Player lost!");
                PrintMatrix(matrix);
            }
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

        private static int MoveAndCheckForRightBorder(int playerCol, char[,] matrix)
        {
            if (playerCol + 1 >= matrix.GetLength(1))
            {
                playerCol = 0;
            }
            else
            {
                playerCol++;
            }

            return playerCol;
        }

        private static int MoveAndCheckForLeftBorder(int playerCol, char[,] matrix)
        {
            if (playerCol - 1 < 0)
            {
                playerCol = matrix.GetLength(1) - 1;
            }
            else
            {
                playerCol--;
            }

            return playerCol;
        }

        private static int MoveAndCheckDownBorder(int playerRow, char[,] matrix)
        {
            if (playerRow + 1 >= matrix.GetLength(0))
            {
                playerRow = 0;
            }
            else
            {
                playerRow++;
            }

            return playerRow;
        }

        private static int MoveAndCheckForUpBorder(int playerRow, char[,] matrix)
        {
            if (playerRow - 1 < 0)
            {
                playerRow = matrix.GetLength(0) - 1;
            }
            else
            {
                playerRow--;
            }

            return playerRow;
        }

        private static void GetMatrixFullAndPlayerCoordinates(ref int playerRow, ref int playerCol, char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = (char)currRow[col];
                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }
    }
}
