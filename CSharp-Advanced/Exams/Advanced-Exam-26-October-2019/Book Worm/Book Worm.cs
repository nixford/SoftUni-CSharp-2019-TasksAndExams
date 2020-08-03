using System;
using System.Text;

namespace Book_Worm
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int rowCoordinatesP = 0;
            int colCoordinatesP = 0;

            GetMatrixFullAndCoordinates(matrix, ref rowCoordinatesP, ref colCoordinatesP);

            int previosRowCoordinates = rowCoordinatesP;
            int previousColCoordinates = colCoordinatesP;

            string command = string.Empty;
            StringBuilder sb = new StringBuilder();
            sb.Append(text);

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "up")
                {
                    if (rowCoordinatesP - 1 < 0)
                    {
                        if (sb.Length > 0)
                        {
                            sb.Remove(sb.Length - 1, 1);
                        }                        
                        continue;
                    }
                    rowCoordinatesP--;
                }
                else if (command == "down")
                {
                    if (rowCoordinatesP + 1 > matrix.GetLength(0) - 1)
                    {
                        if (sb.Length > 0)
                        {
                            sb.Remove(sb.Length - 1, 1);
                        }
                        continue;
                    }
                    rowCoordinatesP++;
                }
                else if (command == "left")
                {
                    if (colCoordinatesP - 1 < 0)
                    {
                        if (sb.Length > 0)
                        {
                            sb.Remove(sb.Length - 1, 1);
                        }
                        continue;
                    }
                    colCoordinatesP--;
                }
                else if (command == "right")
                {
                    if (colCoordinatesP + 1 > matrix.GetLength(1) - 1)
                    {
                        if (sb.Length > 0)
                        {
                            sb.Remove(sb.Length - 1, 1);
                        }
                        continue;
                    }
                    colCoordinatesP++;
                }

                if (matrix[rowCoordinatesP, colCoordinatesP] != '-')
                {
                    sb.Append(matrix[rowCoordinatesP, colCoordinatesP]);
                    matrix[rowCoordinatesP, colCoordinatesP] = 'P';
                    matrix[previosRowCoordinates, previousColCoordinates] = '-';
                    previosRowCoordinates = rowCoordinatesP;
                    previousColCoordinates = colCoordinatesP;
                }
                else
                {
                    matrix[rowCoordinatesP, colCoordinatesP] = 'P';
                    matrix[previosRowCoordinates, previousColCoordinates] = '-';
                    previosRowCoordinates = rowCoordinatesP;
                    previousColCoordinates = colCoordinatesP;
                }
            }

            Console.WriteLine(sb.ToString());
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void GetMatrixFullAndCoordinates(char[,] matrix, ref int rowCoordinatesP, ref int colCoordinates)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                    if (currRow[col] == 'P')
                    {
                        rowCoordinatesP = row;
                        colCoordinates = col;
                    }
                }
            }
        }
    }
}
