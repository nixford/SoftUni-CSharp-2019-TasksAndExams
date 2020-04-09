using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Adjacent_Equal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> inputList = Console.ReadLine().Split(' ').Select(double.Parse).ToList();

            for (int i = 0; i < inputList.Count; i++)
            {
                if (inputList.Count <= i + 1)
                {
                    break;
                }
                double currIndex = inputList[i];
                double nextIndex = inputList[i + 1];
                if (currIndex == nextIndex)
                {                    
                    inputList.RemoveAt(i + 1);
                    inputList[i] = currIndex + nextIndex;                    
                    i = -1;
                }
                
            }
            Console.WriteLine(string.Join(" ", inputList));
        }
    }
}
