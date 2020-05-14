using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> resultList = new List<int>(firstList.Count + secondList.Count);
            int countFirst = 0;
            int countSecond = 0;

            if (secondList.Count < firstList.Count)
            {
                for (int i = 0; i < secondList.Count * 2; i++)
                {
                    if (i % 2 == 0)
                    {
                        resultList.Add(firstList[countFirst]);
                        countFirst++;
                    }
                    else
                    {
                        resultList.Add(secondList[countSecond]);
                        countSecond++;
                    }                    
                }
                for (int i = secondList.Count; i < firstList.Count; i++)
                {
                    resultList.Add(firstList[i]);
                }
            }
            else
            {
                for (int i = 0; i < firstList.Count * 2; i++)
                {
                    if (i % 2 == 0)
                    {
                        resultList.Add(firstList[countFirst]);
                        countFirst++;                        
                    }
                    else
                    {
                        resultList.Add(secondList[countSecond]);
                        countSecond++;
                    }
                }
                for (int i = firstList.Count; i < secondList.Count; i++)
                {
                    resultList.Add(secondList[i]);
                }
            }
            Console.WriteLine(string.Join(" ", resultList));
        }
    }
}
