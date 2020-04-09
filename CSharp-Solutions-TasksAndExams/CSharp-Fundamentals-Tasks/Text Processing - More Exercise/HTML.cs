using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string titleOfArticle = Console.ReadLine();
            Console.WriteLine("<h1>");
            Console.WriteLine(new string(' ', 4) + titleOfArticle);
            Console.WriteLine("</h1>");

            string contentOfArticle = Console.ReadLine();
            Console.WriteLine("<article>");
            Console.WriteLine(new string(' ', 4) + contentOfArticle);
            Console.WriteLine("</article>");

            string currInput = Console.ReadLine();
            

            while (currInput != "end of comments")
            {
                Console.WriteLine("<div>");
                Console.WriteLine(new string(' ', 4) + currInput);
                Console.WriteLine("</div>");
                currInput = Console.ReadLine();
            }
        }
    }
}
