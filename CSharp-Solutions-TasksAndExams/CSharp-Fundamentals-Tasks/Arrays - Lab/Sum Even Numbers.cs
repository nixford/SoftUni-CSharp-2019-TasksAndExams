using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();
            string[] elements = inputLine.Split(' ');
            int[] valuePerElement = elements.Select(int.Parse).ToArray();

            int evenSum = 0;
            int currentValuePerElement = 0;

            for (int i = 0; i < valuePerElement.Length; i++)
            {
                currentValuePerElement = valuePerElement[i];
                if (currentValuePerElement % 2 == 0)
                {
                    evenSum = evenSum + currentValuePerElement;
                }
            }
            Console.WriteLine(evenSum);
        }
    }
}
