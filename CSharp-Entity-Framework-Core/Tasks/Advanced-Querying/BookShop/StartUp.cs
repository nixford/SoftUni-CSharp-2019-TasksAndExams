namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.VisualBasic;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var context = new BookShopContext();

            //int input = int.Parse(Console.ReadLine());
            //string input = Console.ReadLine();
            //IncreasePrices(context);

            Console.WriteLine(RemoveBooks(context));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();
            AgeRestriction ageRestr = new AgeRestriction();

            if (command.ToUpper() == AgeRestriction.Minor.ToString().ToUpper())
            {
                ageRestr = AgeRestriction.Minor;
            }
            else if (command.ToUpper() == AgeRestriction.Teen.ToString().ToUpper())
            {
                ageRestr = AgeRestriction.Teen;
            }
            else if (command.ToUpper() == AgeRestriction.Adult.ToString().ToUpper())
            {
                ageRestr = AgeRestriction.Adult;
            }

            var books = context.Books
                    .Where(b => b.AgeRestriction == ageRestr)
                    .Select(b => new
                    {
                        Title = b.Title,
                    })
                    .OrderBy(b => b.Title)
                    .ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => (int)b.EditionType == 2 && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    Title = b.Title,
                })
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }


        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books                
                .Select(b => new 
                { 
                    Title = b.Title,
                    Price = b.Price,                
                })
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }


        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => new 
                { 
                    b.Title,
                })
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.Split(' ').ToArray();
            StringBuilder sb = new StringBuilder();
            List<string> temp = new List<string>();

            foreach (var category in categories)
            {
                var books = context.Books
               .Where(b => b.BookCategories
                    .Any(c => c.Category.Name.ToUpper() == category.ToUpper()))
               .Select(b => new 
               { 
                    b.Title,
               })               
               .ToList();

                foreach (var book in books)
                {
                    temp.Add(book.Title);
                }
            }
            temp.Sort();

            foreach (var book in temp)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }


        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < dateTime)
                .Select(b => new 
                { 
                    b.Title,
                    b.EditionType,
                    b.Price,
                    b.ReleaseDate
                })                
                .OrderByDescending(b => b.ReleaseDate)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new 
                {
                    a.FirstName,
                    a.LastName,
                })
                .OrderBy(a => a.FirstName + a.LastName)
                .ToList();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName}");
            }

            return sb.ToString().TrimEnd();
        }


        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Title.ToUpper().Contains(input.ToUpper()))
                .Select(b => new
                {
                    b.Title,                    
                })
                .OrderBy(b => b.Title)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Where(a => a.LastName.ToUpper().StartsWith(input.ToUpper()))
                .Select(a => new 
                {
                    a.FirstName,
                    a.LastName,
                    BooksForAuthor = a.Books.OrderBy(b => b.BookId).ToList(),                    
                })
                .ToList();

            foreach (var author in authors)
            {
                foreach (var currBook in author.BooksForAuthor)
                {
                    sb.AppendLine($"{currBook.Title} ({author.FirstName} {author.LastName})");
                }
            }

            return sb.ToString().TrimEnd();
        }


        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(b => b.Title.Length > lengthCheck);

            int result = books.Count();

            return result;
        }


        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    BookCount = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(b => b.BookCount)
                .ToList();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName} - {author.BookCount}");
            }

            return sb.ToString().TrimEnd();
        }


        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(i => i.Book.Price * i.Book.Copies)
                })
                .OrderByDescending(b => b.Profit)
                .ThenBy(c => c.Name)
                .ToList();            

            foreach (var category in categories)
            {
                sb.AppendLine($"{category.Name} ${category.Profit:f2}");
            }

            return sb.ToString().TrimEnd();
        }


        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    CategoryName = c.Name,
                    BooksNames = c.CategoryBooks
                    .Select(b => new
                    {
                        b.Book.Title,
                        b.Book.ReleaseDate,
                        b.Book.ReleaseDate.Value.Year
                    })
                    .OrderByDescending(b => b.ReleaseDate)
                    .Take(3)
                    .ToList()
                })
                .ToList();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.BooksNames)
                {
                    sb.AppendLine($"{book.Title} ({book.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }


        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books.Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books.Where(b => b.Copies < 4200);
            int count = books.Count();

            foreach (var book in books)
            {
                context.Books.Remove(book);
            }

            context.SaveChanges();

            return count;
        }


    }
}
