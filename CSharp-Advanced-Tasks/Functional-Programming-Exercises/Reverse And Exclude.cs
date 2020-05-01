using System;
using System.Linq;

namespace Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int divisibleNumber = 0;
            Func<string, int> parcingFunc = x => int.Parse(x);
            Func<int[], int[]> divFunc = x => x.Where((x) => x % divisibleNumber != 0)
            .Reverse()
            .ToArray();
            Action<int[]> printAction = (arr) => Console.Write(string.Join(" ", arr));

            int[] numbersArr = Console.ReadLine()
                .Split()
                .Select(parcingFunc)
                .ToArray();
            divisibleNumber = int.Parse(Console.ReadLine());

            printAction(divFunc(numbersArr));
        }        
    }
}
