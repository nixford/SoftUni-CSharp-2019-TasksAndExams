using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimestions = GetSplitedAndParcedInput(Console.ReadLine());            
            int row = dimestions[0];
            int col = dimestions[1];

            int[,] matrix = new int[row, col];
            int value = 0;
            long sum = 0;

            GetFullMatrix(row, col, matrix, value);            
            
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Let the Force be with you")
            {
                int[] ivoCoordinates = GetSplitedAndParcedInput(command);
                int rowIvo = ivoCoordinates[0];
                int colIvo = ivoCoordinates[1];

                int[] evilCoordinates = GetSplitedAndParcedInput(Console.ReadLine());
                int rowEvil = evilCoordinates[0];
                int colEvil = evilCoordinates[1];

                GetDestroyedStrs(matrix, ref rowEvil, ref colEvil);

                GetIvoScores(matrix, ref sum, ref rowIvo, ref colIvo);
            }
            Console.WriteLine(sum);
        }

        private static void GetIvoScores(int[,] matrix, ref long sum, ref int rowIvo, ref int colIvo)
        {
            while (rowIvo >= 0 && colIvo < matrix.GetLength(1))
            {
                if (rowIvo >= 0 && rowIvo < matrix.GetLength(0) &&
                    colIvo >= 0 && colIvo < matrix.GetLength(1))
                {
                    sum += matrix[rowIvo, colIvo];
                }
                colIvo++;
                rowIvo--;
            }
        }

        private static void GetDestroyedStrs(int[,] matrix, ref int rowEvil, ref int colEvil)
        {
            while (rowEvil >= 0 && colEvil >= 0)
            {
                if (rowEvil >= 0 && rowEvil < matrix.GetLength(0) &&
                    colEvil >= 0 && colEvil < matrix.GetLength(1))
                {
                    matrix[rowEvil, colEvil] = 0;
                }
                rowEvil--;
                colEvil--;
            }
        }

        private static int[] GetSplitedAndParcedInput(string command)
        {
            return command
                .Split(new string[] { " " },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        private static int GetFullMatrix(int row, int col, int[,] matrix, int value)
        {
            for (int currRow = 0; currRow < row; currRow++)
            {
                for (int currCol = 0; currCol < col; currCol++)
                {
                    matrix[currRow, currCol] = value++;
                }
            }

            return value;
        }
    }
}
