using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] arrayFirst = new int[numbers.Length / 2];
            int[] arraySecond = new int[numbers.Length / 2];
            int[] arraySum = new int[numbers.Length / 2];
            int countFirst = 0;
            int countSecond = 0;
            
            int[] arrayFirstReverced = new int[arrayFirst.Length];
            int[] arraySecondReverced = new int[arrayFirst.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i < (numbers.Length / 2) / 2 || i >= numbers.Length - ((numbers.Length / 2) / 2))
                {                    
                    arrayFirst[countFirst] = numbers[i];
                    countFirst++;                    
                }
                else if (i >= (numbers.Length / 2) / 2 && i < numbers.Length - ((numbers.Length / 2) / 2))
                {                    
                    arraySecond[countSecond] = numbers[i];
                    countSecond++;
                }               
            }
            for (int i = 0; i < arrayFirst.Length / 2; i++)
            {
                arrayFirstReverced[i] = arrayFirst[(arrayFirst.Length / 2) - 1 - i];
            }
            for (int j = 0; j < arrayFirst.Length / 2; j++)
            {
                arrayFirstReverced[(arrayFirst.Length / 2) + j] = arrayFirst[arrayFirst.Length - 1 - j];
            }

            for (int i = 0; i < arrayFirst.Length; i++)
            {
                arraySum[i] = arrayFirstReverced[i] + arraySecond[i];
            }
            Console.WriteLine(String.Join(" ", arraySum));                   
        }
    }
}
