using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            //int n = int.Parse(Console.ReadLine());

            //int[] wagonsCount = new int [n];

            //int sum = 0;

            //for (int i = 0; i < wagonsCount.Length; i++)
            //{
            //    wagonsCount[i] = int.Parse(Console.ReadLine());                
            //    sum = sum + wagonsCount[i];              
            //}
            //for (int i = 0; i < wagonsCount.Length; i++)
            //{                
            //    Console.Write(wagonsCount[i] + " ");
            //}
            //Console.WriteLine();
            //Console.WriteLine(sum);

            int countWagon = int.Parse(Console.ReadLine());
            int[] countOfPeople = new int[countWagon];
            int sum = 0;

            for (int i = 0; i < countWagon; i++)
            {
                countOfPeople[i] = int.Parse(Console.ReadLine());                
            }
            sum = countOfPeople.Sum();
            Console.WriteLine(string.Join(" ", countOfPeople));       
            Console.WriteLine(sum);
        }
    }
}
