using System;
using System.Linq;

namespace Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsNumber = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rowsNumber, rowsNumber];

            int counter = 0;

            while (true)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                if (input[0] == "Add")
                {
                    int rowChange = int.Parse(input[1]);
                    int colChange = int.Parse(input[2]);
                    int valueIncrease = int.Parse(input[3]);
                    if (rowChange >= 0 && rowChange < matrix.GetLength(0) &&
                        colChange >= 0 && colChange < matrix.GetLength(1))
                    {
                        matrix[rowChange, colChange] += valueIncrease;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                else if (input[0] == "Subtract")
                {
                    int rowChange = int.Parse(input[1]);
                    int colChange = int.Parse(input[2]);
                    int valueIDecrease = int.Parse(input[3]);
                    if (rowChange >= 0 && rowChange < matrix.GetLength(0) &&
                        colChange >= 0 && colChange < matrix.GetLength(1))
                    {
                        matrix[rowChange, colChange] -= valueIDecrease;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                else if (input[0] == "END")
                {
                    break;
                }
                else
                {                    
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[counter, col] = int.Parse(input[col]);
                    }
                    counter++;
                }                
            }

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
