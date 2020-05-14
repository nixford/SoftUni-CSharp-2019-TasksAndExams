using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputText = Console.ReadLine().Split(' ').ToArray();
            char[] charsArr1 = inputText[0].ToCharArray();
            char[] charsArr2 = inputText[1].ToCharArray();

            int totalSum = 0;

            if (charsArr1.Length == charsArr2.Length)
            {
                for (int i = 0; i < charsArr1.Length; i++)
                {
                    totalSum = totalSum + ((int)charsArr1[i] * (int)charsArr2[i]); 
                }
            }

            if (charsArr1.Length > charsArr2.Length)
            {
                for (int i = 0; i < charsArr2.Length; i++)
                {
                    totalSum = totalSum + ((int)charsArr1[i] * (int)charsArr2[i]);                    
                }
                for (int j = charsArr2.Length; j < charsArr1.Length; j++)
                {
                    totalSum = totalSum + (int)charsArr1[j];
                }
            }

            if (charsArr1.Length < charsArr2.Length)
            {
                for (int i = 0; i < charsArr1.Length; i++)
                {
                    totalSum = totalSum + ((int)charsArr1[i] * (int)charsArr2[i]);                    
                }
                for (int j = charsArr1.Length; j < charsArr2.Length; j++)
                {
                    totalSum = totalSum + (int)charsArr2[j];
                }
            }
            Console.WriteLine(totalSum);
        }
    }
}
