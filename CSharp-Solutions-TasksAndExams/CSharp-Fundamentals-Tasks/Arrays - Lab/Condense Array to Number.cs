using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            while (array.Length > 1)
            {
                int[] condensed = new int[array.Length - 1]; // намаля със всяка итерация променливата "array.Length - 1". Със всяка итерация се задава НОВ масив, който е с дължина 1-ца по-мако.
                for (int i = 0; i < condensed.Length; i++) // този цикъл служи за попълване на всички елементи на масива condensed.
                {
                    condensed[i] = array[i] + array[i + 1]; // След като се създаде нов масив, елементите му се ПЪЛНЯТ с данни от сбора на настоящия и последващия елемент от масива array.
                }

                array = condensed;
            }
            Console.WriteLine(array[0]); // принтира се нулевия индекс/елемент, защото след всички пресмятания се стига до него.
        }
    }
}
