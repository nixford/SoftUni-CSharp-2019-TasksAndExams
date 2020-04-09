using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypt__Sort_and_Print_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string[] array = new string[num];            
            string currentWord = string.Empty;
            string allConsunant = string.Empty;
            string allVowels = string.Empty;
            string vowels = "aeiouAEIOU";
            int sumConsunants = 0;
            int sumVowels = 0;
            int[] sumTotal = new int[num];

            for (int i = 0; i < num; i++)
            {
                sumConsunants = 0;
                sumVowels = 0;
                array[i] = Console.ReadLine();
                currentWord = array[i];
                allConsunant = new string(currentWord.Where(c => !vowels.Contains(c)).ToArray());
                allVowels = new string(currentWord.Where(c => vowels.Contains(c)).ToArray());
                char[] arrayConsunants = allConsunant.ToCharArray();
                char[] arrayVowels = allVowels.ToCharArray();

                for (int j = 0; j < arrayConsunants.Length; j++)
                {
                    char currentLetterConsunant = arrayConsunants[j];
                    int result = (int)currentLetterConsunant / currentWord.Length;
                    sumConsunants = sumConsunants + result;
                }

                for (int j = 0; j < arrayVowels.Length; j++)
                {
                    char currentLetterVowel = arrayVowels[j];
                    int result2 = (int)currentLetterVowel * currentWord.Length;
                    sumVowels = sumVowels + result2;
                }
                sumTotal[i] = sumConsunants + sumVowels;                              
            }
            for (int i = 0; i < sumTotal.Length; i++)
            {
                Array.Sort(sumTotal);
                Console.WriteLine(sumTotal[i]);
            }            
        }
    }
}

