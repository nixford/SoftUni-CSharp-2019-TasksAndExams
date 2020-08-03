using System;

namespace Rhombus_of_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintRow(n);
        }

        private static void PrintRow(int n)
        {
            // Top part
            for (int row = 1; row  <= n; row++)
            {
                for (int col = row; col < n; col++)
                {
                    Console.Write(" ");                    
                }
                for (int col2 = 0; col2 < row; col2++)
                {
                    Console.Write("*");
                    if (row > 1)
                    {
                        Console.Write(" ");
                    }
                }
                for (int col = row; col < n; col++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            // Bottom part
            for (int row = 1; row <= n; row++)
            {
                for (int col = 0; col < row; col++)
                {
                    Console.Write(" ");
                }
                for (int col = row; col < n; col++)
                {
                    Console.Write("*");
                    if (row < n)
                    {
                        Console.Write(" ");
                    }
                }
                for (int col = 0; col < row; col++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
