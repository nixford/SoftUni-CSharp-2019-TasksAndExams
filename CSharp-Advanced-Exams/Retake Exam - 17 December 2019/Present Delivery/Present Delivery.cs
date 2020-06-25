using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Present_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfPresentsM = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            int rowSanta = 0;
            int colSanta = 0;           
            int countOfGoodKids = 0;
            int presentsGave = 0;

            char[,] matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currRow = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                    if (currRow[col] == 'S')
                    {
                        rowSanta = row;
                        colSanta = col;
                    }
                    if (currRow[col] == 'V')
                    {
                        countOfGoodKids++;
                    }
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Christmas morning" && countOfPresentsM > 0)
            {                
                if (command == "up")
                {
                    if (matrix[rowSanta - 1, colSanta] == 'V')
                    {
                        countOfPresentsM--;
                        presentsGave++;
                        rowSanta = GetUpRow(rowSanta, colSanta, matrix);
                    }
                    else if (matrix[rowSanta - 1, colSanta] == 'X' || matrix[rowSanta - 1, colSanta] == '-')
                    {
                        rowSanta = GetUpRow(rowSanta, colSanta, matrix);
                    }
                    else if ((matrix[rowSanta - 1, colSanta] == 'C'))
                    {
                        rowSanta = GetUpRow(rowSanta, colSanta, matrix);
                        if (matrix[rowSanta - 1, colSanta] == 'V' || matrix[rowSanta - 1, colSanta] == 'X')
                        {
                            GetCOptionDownRow(ref countOfPresentsM, rowSanta, colSanta, ref presentsGave, matrix);
                            if (countOfPresentsM <= 0) { break; }
                        }
                        if (matrix[rowSanta + 1, colSanta] == 'V' || matrix[rowSanta + 1, colSanta] == 'X')
                        {
                            if (matrix[rowSanta + 1, colSanta] == 'V')
                            {
                                presentsGave++;
                            }
                            matrix[rowSanta + 1, colSanta] = '-';
                            countOfPresentsM--;
                            if (countOfPresentsM <= 0) { break; }
                        }
                        if (matrix[rowSanta, colSanta - 1] == 'V' || matrix[rowSanta, colSanta - 1] == 'X')
                        {                                              
                            if (matrix[rowSanta, colSanta - 1] == 'V')
                            {
                                presentsGave++;
                            }
                            matrix[rowSanta, colSanta - 1] = '-';
                            countOfPresentsM--;
                            if (countOfPresentsM <= 0) { break; }
                        }
                        if (matrix[rowSanta, colSanta + 1] == 'V' || matrix[rowSanta, colSanta + 1] == 'X')
                        {                                           
                            if (matrix[rowSanta, colSanta + 1] == 'V')
                            {
                                presentsGave++;
                            }
                            matrix[rowSanta, colSanta + 1] = '-';
                            countOfPresentsM--;
                            if (countOfPresentsM <= 0) { break; }
                        }
                    }                   
                }
                else if (command == "down")
                {
                    if (matrix[rowSanta + 1, colSanta] == 'V')
                    {
                        countOfPresentsM--;
                        presentsGave++;
                        rowSanta = GetDownRow(rowSanta, colSanta, matrix);
                    }
                    else if (matrix[rowSanta + 1, colSanta] == 'X' || matrix[rowSanta + 1, colSanta] == '-')
                    {
                        rowSanta = GetDownRow(rowSanta, colSanta, matrix);
                    }
                    else if ((matrix[rowSanta + 1, colSanta] == 'C'))
                    {
                        rowSanta = GetDownRow(rowSanta, colSanta, matrix);
                        if (matrix[rowSanta - 1, colSanta] == 'V' || matrix[rowSanta - 1, colSanta] == 'X')
                        {
                            GetCOptionDownRow(ref countOfPresentsM, rowSanta, colSanta, ref presentsGave, matrix);
                            if (countOfPresentsM <= 0) { break; }
                        }
                        if (matrix[rowSanta + 1, colSanta] == 'V' || matrix[rowSanta + 1, colSanta] == 'X')
                        {
                            if (matrix[rowSanta + 1, colSanta] == 'V')
                            {
                                presentsGave++;
                            }
                            matrix[rowSanta + 1, colSanta] = '-';
                            countOfPresentsM--;
                            if (countOfPresentsM <= 0) { break; }
                        }
                        if (matrix[rowSanta, colSanta - 1] == 'V' || matrix[rowSanta, colSanta - 1] == 'X')
                        {                
                            if ((matrix[rowSanta, colSanta - 1] == 'V'))
                            {
                                presentsGave++;
                            }
                            matrix[rowSanta, colSanta - 1] = '-';
                            countOfPresentsM--;
                            if (countOfPresentsM <= 0) { break; }
                        }
                        if (matrix[rowSanta, colSanta + 1] == 'V' || matrix[rowSanta, colSanta + 1] == 'X')
                        {
                            if (matrix[rowSanta, colSanta + 1] == 'V')
                            {
                                presentsGave++;
                            }
                            matrix[rowSanta, colSanta + 1] = '-';
                            countOfPresentsM--;
                            if (countOfPresentsM <= 0) { break; }
                        }
                    }
                }
                else if (command == "left")
                {
                    if (matrix[rowSanta, colSanta - 1] == 'V')
                    {
                        countOfPresentsM--;
                        presentsGave++;
                        colSanta = GetLeftColumn(rowSanta, colSanta, matrix);
                    }
                    else if (matrix[rowSanta, colSanta - 1] == 'X' || matrix[rowSanta, colSanta - 1] == '-')
                    {
                        colSanta = GetLeftColumn(rowSanta, colSanta, matrix);
                    }
                    else if ((matrix[rowSanta, colSanta - 1] == 'C'))
                    {
                        colSanta = GetLeftColumn(rowSanta, colSanta, matrix);
                        if (matrix[rowSanta - 1, colSanta] == 'V' || matrix[rowSanta - 1, colSanta] == 'X')
                        {
                            GetCOptionDownRow(ref countOfPresentsM, rowSanta, colSanta, ref presentsGave, matrix);
                            if (countOfPresentsM <= 0) { break; }
                        }
                        if (matrix[rowSanta + 1, colSanta] == 'V' || matrix[rowSanta + 1, colSanta] == 'X')
                        {                     
                            if (matrix[rowSanta + 1, colSanta] == 'V')
                            {
                                presentsGave++;
                            }
                            matrix[rowSanta + 1, colSanta] = '-';
                            countOfPresentsM--;
                            if (countOfPresentsM <= 0) { break; }
                        }
                        if (matrix[rowSanta, colSanta - 1] == 'V' || matrix[rowSanta, colSanta - 1] == 'X')
                        {                 
                            if (matrix[rowSanta, colSanta - 1] == 'V')
                            {
                                presentsGave++;
                            }
                            matrix[rowSanta, colSanta - 1] = '-';
                            countOfPresentsM--;
                            if (countOfPresentsM <= 0) { break; }
                        }
                        if (matrix[rowSanta, colSanta + 1] == 'V' || matrix[rowSanta, colSanta + 1] == 'X')
                        {                      
                            if (matrix[rowSanta, colSanta + 1] == 'V')
                            {
                                presentsGave++;
                            }
                            matrix[rowSanta, colSanta + 1] = '-';
                            countOfPresentsM--;
                            if (countOfPresentsM <= 0) { break; }
                        }
                    }
                }
                else if (command == "right")
                {
                    if (matrix[rowSanta, colSanta + 1] == 'V')
                    {
                        countOfPresentsM--;
                        presentsGave++;
                        colSanta = GetRightColumn(rowSanta, colSanta, matrix);
                    }
                    else if (matrix[rowSanta, colSanta + 1] == 'X' || matrix[rowSanta, colSanta + 1] == '-')
                    {
                        colSanta = GetRightColumn(rowSanta, colSanta, matrix);
                    }
                    else if ((matrix[rowSanta, colSanta + 1] == 'C'))
                    {
                        colSanta = GetRightColumn(rowSanta, colSanta, matrix);
                        if (matrix[rowSanta - 1, colSanta] == 'V' || matrix[rowSanta - 1, colSanta] == 'X')
                        {
                            GetCOptionDownRow(ref countOfPresentsM, rowSanta, colSanta, ref presentsGave, matrix);
                            if (countOfPresentsM <= 0) { break; }
                        }
                        if (matrix[rowSanta + 1, colSanta] == 'V' || matrix[rowSanta + 1, colSanta] == 'X')
                        {
                            if (matrix[rowSanta + 1, colSanta] == 'V')
                            {
                                presentsGave++;
                            }
                            matrix[rowSanta + 1, colSanta] = '-';
                            countOfPresentsM--;
                            if (countOfPresentsM <= 0) { break; }
                        }
                        if (matrix[rowSanta, colSanta - 1] == 'V' || matrix[rowSanta, colSanta - 1] == 'X')
                        {
                            if (matrix[rowSanta, colSanta - 1] == 'V')
                            {
                                presentsGave++;
                            }
                            matrix[rowSanta, colSanta - 1] = '-';
                            countOfPresentsM--;
                            if (countOfPresentsM <= 0) { break; }
                        }
                        if (matrix[rowSanta, colSanta + 1] == 'V' || matrix[rowSanta, colSanta + 1] == 'X')
                        {
                            if (matrix[rowSanta, colSanta + 1] == 'V')
                            {
                                presentsGave++;
                            }
                            matrix[rowSanta, colSanta + 1] = '-';
                            countOfPresentsM--;
                            if (countOfPresentsM <= 0) { break; }
                        }
                    }
                }
            }

            matrix[rowSanta, colSanta] = 'S';

            if (countOfPresentsM > 0)
            {
                if (countOfGoodKids == presentsGave)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"Good job, Santa! {countOfGoodKids} happy nice kid/s.");
                }
                else
                {                   
                    PrintMatrix(matrix);
                    Console.WriteLine($"No presents for {countOfGoodKids - presentsGave} nice kid/s.");
                }
            }
            else
            {
                if (countOfGoodKids == presentsGave)
                {
                    Console.WriteLine("Santa ran out of presents!");
                    PrintMatrix(matrix);
                    Console.WriteLine($"Good job, Santa! {countOfGoodKids} happy nice kid/s.");
                }
                else
                {
                    Console.WriteLine("Santa ran out of presents!");
                    PrintMatrix(matrix);
                    Console.WriteLine($"No presents for {countOfGoodKids - presentsGave} nice kid/s.");
                }
            }
        }

        private static void GetCOptionDownRow(ref int countOfPresentsM, int rowSanta, int colSanta, ref int presentsGave, char[,] matrix)
        {
            if (matrix[rowSanta - 1, colSanta] == 'V')
            {
                presentsGave++;
            }
            matrix[rowSanta - 1, colSanta] = '-';
            countOfPresentsM--;
        }
        private static int GetRightColumn(int rowSanta, int colSanta, char[,] matrix)
        {
            matrix[rowSanta, colSanta] = '-';
            colSanta++;
            matrix[rowSanta, colSanta] = '-';
            return colSanta;
        }
        private static int GetLeftColumn(int rowSanta, int colSanta, char[,] matrix)
        {
            matrix[rowSanta, colSanta] = '-';
            colSanta--;
            matrix[rowSanta, colSanta] = '-';
            return colSanta;
        }
        private static int GetDownRow(int rowSanta, int colSanta, char[,] matrix)
        {
            matrix[rowSanta, colSanta] = '-';
            rowSanta++;
            matrix[rowSanta, colSanta] = '-';
            return rowSanta;
        }
        private static int GetUpRow(int rowSanta, int colSanta, char[,] matrix)
        {
            matrix[rowSanta, colSanta] = '-';
            rowSanta--;
            matrix[rowSanta, colSanta] = '-';
            return rowSanta;
        }
        private static void PrintMatrix(char[,] matrix)
        {
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
