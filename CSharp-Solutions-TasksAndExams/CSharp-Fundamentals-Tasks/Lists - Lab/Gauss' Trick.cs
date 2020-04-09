using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauss__Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<double> inputList = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            //List<double> outputList = new List<double>();

            //if (inputList.Count % 2 == 0)
            //{
            //    for (int i = 0; i <= inputList.Count / 2; i++)
            //    {
            //        outputList.Insert(0, inputList[i] + inputList[inputList.Count - 1 - i]);
            //        inputList.RemoveAt(i);
            //        inputList.RemoveAt(inputList.Count - 1);
            //    }
            //    Console.WriteLine(string.Join(" ", outputList));
            //}
            //else
            //{
            //    double tempMiddle = inputList.Count / 2 + 1;
            //    for (int i = 0; i < inputList.Count / 2; i++)
            //    {
            //        outputList.Insert(0, inputList[i] + inputList[inputList.Count - 1 - i]);
            //        inputList.RemoveAt(i);
            //        inputList.RemoveAt(inputList.Count - 1);
            //    }
            //    outputList.Add(tempMiddle);
            //    Console.WriteLine(string.Join(" ", outputList));
            //}
                        
            List<double> numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            GaussTrick(numbers);
        }


        static void GaussTrick(List<double> seriesOfNumbers)
        {
            // retrieve and keep the initial count
            var itemCount = seriesOfNumbers.Count;

            // iterate the amount of times as the count
            for (int i = 0; i < itemCount / 2; i++)
            {
                // retrieve relevant values
                var valueAtIndexPosition = seriesOfNumbers[i];
                var valueOfIndexAtLastPosition = seriesOfNumbers.Count - 1; // zero based
                var valueAtLastPosition = seriesOfNumbers[valueOfIndexAtLastPosition];

                // sum the index and current last value
                var iterationSum = valueAtIndexPosition + valueAtLastPosition;

                // assign the summed value to the iteration index position
                seriesOfNumbers[i] = iterationSum;

                // Remove the item at the last position
                seriesOfNumbers.RemoveAt(valueOfIndexAtLastPosition);
            }
            Console.WriteLine(string.Join(" ", seriesOfNumbers));
        }
    }
}
