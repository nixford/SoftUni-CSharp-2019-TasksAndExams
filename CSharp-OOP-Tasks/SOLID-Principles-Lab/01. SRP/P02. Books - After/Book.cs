using System;
using System.Collections.Generic;
using System.Text;

namespace P02._Books___After
{
    public class Book
    {
        public string Title { get; set; }

        public string Author { get; set; }        

        public string TurnPage(int page)
        {
            return "Current page";
        }
    }
}
