using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            //string [] array1 = Console.ReadLine().Split(' ');
            //string [] array2 = Console.ReadLine().Split(' ');

            //string match = string.Empty;

            //foreach (var element in array2)
            //{
            //    if (array1.Contains(element)) // Determines whether a sequence contains a specified element.
            //    {
            //        match = match + " " + element;                    
            //    }
            //}
            //Console.Write($"{match.Trim()}"); // Returns a new string in which all leading and trailing occurrences of a set of specified characters from the current string are removed.
            //Console.WriteLine();

            string[] array1 = Console.ReadLine().Split(' ').ToArray();
            string[] array2 = Console.ReadLine().Split(' ').ToArray();
            string result = string.Empty;

            foreach (var word1 in array2)
            {
                foreach (var word2 in array1)
                {
                    if (word1 == word2)
                    {
                        result = result + word1 + " ";
                    }                    
                }
            }
            Console.WriteLine(result);
        }
    }
}
