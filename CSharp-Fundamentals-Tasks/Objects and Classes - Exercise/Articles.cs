using System;
using System.Collections.Generic;
using System.Linq;

namespace LecturePractice
{
    public class Program
    {        
        public static void Main()
        {
            
            int number = int.Parse(Console.ReadLine());            

            for (int i = 0; i < number; i++)
            {
                List<string> newInput = Console.ReadLine().Split(':').Select(s => s.Trim()).ToList();

                if (newInput[0] == "Edit")
                {
                    article.Content = newInput[1];
                }
                else if (newInput[0] == "ChangeAuthor")
                {
                    article.Author = newInput[1];
                }
                else if (newInput[0] == "Rename")
                {
                    article.Title = newInput[1];
                }

                Article article = new Article
            {
                string[] data =  Console.ReadLine().Split(',').ToArray();

                Title = inputText[0],
                Content = inputText[1],
                Author = inputText[2]
            };

        }
            Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
        }

        public class Article
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }
        }
    }
}