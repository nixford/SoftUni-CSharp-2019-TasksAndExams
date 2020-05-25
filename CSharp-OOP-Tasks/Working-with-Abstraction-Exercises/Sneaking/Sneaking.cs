using System;

namespace P06_Sneaking
{
    public class Sneaking
    {        
        static void Main()
        {
            
            int[] samPosition = new int[2];

            int n = int.Parse(Console.ReadLine());
            char[][] room = new char[n][];
            GetFullJagedArray(n, room);
            var moves = Console.ReadLine().ToCharArray();

            GetSamPosition(room, samPosition);

            for (int i = 0; i < moves.Length; i++)
            {
                GetMoves(room);

                int[] getEnemy = new int[2];
                CheckForEnemy(room, samPosition, getEnemy);

                if (samPosition[1] < getEnemy[1] &&
                    room[getEnemy[0]][getEnemy[1]] == 'd' &&
                    getEnemy[0] == samPosition[0])
                {
                    room[samPosition[0]][samPosition[1]] = 'X';
                    Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                    PrintJaggedArray(room);
                    break;
                }
                else if (getEnemy[1] < samPosition[1] &&
                    room[getEnemy[0]][getEnemy[1]] == 'b' &&
                    getEnemy[0] == samPosition[0])
                {
                    room[samPosition[0]][samPosition[1]] = 'X';
                    Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                    PrintJaggedArray(room);
                    break;
                }

                room[samPosition[0]][samPosition[1]] = '.';

                ChangingSamPosition(samPosition, moves, i);

                room[samPosition[0]][samPosition[1]] = 'S';

                CheckForEnemy(room, samPosition, getEnemy);

                if (room[getEnemy[0]][getEnemy[1]] == 'N' && samPosition[0] == getEnemy[0])
                {
                    room[getEnemy[0]][getEnemy[1]] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    PrintJaggedArray(room);
                    break;
                }
            }
        }

        private static void ChangingSamPosition(int[] samPosition, char[] moves, int i)
        {
            switch (moves[i])
            {
                case 'U':
                    samPosition[0]--;
                    break;
                case 'D':
                    samPosition[0]++;
                    break;
                case 'L':
                    samPosition[1]--;
                    break;
                case 'R':
                    samPosition[1]++;
                    break;
                default:
                    break;
            }
        }

        private static void GetSamPosition(char[][] room, int[] samPosition)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        samPosition[0] = row;
                        samPosition[1] = col;
                    }
                }
            }
        }

        private static void CheckForEnemy(char[][] room, int[] samPosition, int[] getEnemy)
        {
            for (int j = 0; j < room[samPosition[0]].Length; j++)
            {
                if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
                {
                    getEnemy[0] = samPosition[0];
                    getEnemy[1] = j;
                }
            }
        }

        private static void PrintJaggedArray(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void GetMoves(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            room[row][col] = 'd';
                        }
                    }
                    else if (room[row][col] == 'd')
                    {
                        if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        else
                        {
                            room[row][col] = 'b';
                        }
                    }
                }
            }
        }

        private static void GetFullJagedArray(int n, char[][] room)
        {
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                room[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    room[row][col] = input[col];
                }
            }
        }
    }
}
