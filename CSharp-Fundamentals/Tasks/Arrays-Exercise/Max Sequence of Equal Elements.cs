using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int number = 0;
            int counter = 0;
            int maxLength = 0;
            int maxNumber = 0;
            int previuos = 0;            

            for (int i = 1; i < array.Length; i++)
            {                
                if (array[previuos] == array[i])
                {
                    counter++;
                    number = array[i];
                    if (counter > maxLength)
                    {
                        maxLength = counter;
                        maxNumber = number;
                    }                
                }
                else
                {
                    counter = 0;
                    number = 0;
                }
                previuos++;
            }
            for (int i = 0; i < maxLength + 1; i++)
            {
                Console.Write(maxNumber + " ");
            }
            Console.WriteLine();
        }
    }
}
