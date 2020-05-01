using System;
using System.Linq;

namespace Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parcingFunc = x => int.Parse(x);
            Func<int[], int> selectMinFun = x => x.Min();

            int[] numberArr = Console.ReadLine()
                .Split()
                .Select(parcingFunc)
                .ToArray();

            Console.WriteLine(selectMinFun(numberArr));

            //Console.WriteLine(ReturnMin(numberArr));
        }

        //static int ReturnMin(int[] numberArr)
        //{
        //    return numberArr.Min();
        //}
    }
}
