namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportBookDto[]), new XmlRootAttribute("Books"));
            var booksDtos = (ImportBookDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            List<Book> bookList = new List<Book>();

            StringBuilder sb = new StringBuilder();

            foreach (var bookDto in booksDtos)
            {
                if (!IsValid(bookDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime bookPublishedDate;
                bool bookPublishedDateValid = DateTime.TryParseExact
                    (bookDto.PublishedOn, "MM/dd/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out bookPublishedDate);

                if (!bookPublishedDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var book = new Book()
                {
                    Name = bookDto.Name,
                    Genre = (Genre)bookDto.Genre,
                    Price = Math.Round(bookDto.Price, 2),
                    PublishedOn = bookPublishedDate,
                };

                    sb.AppendLine(String.Format(SuccessfullyImportedBook, bookDto.Name, bookDto.Price));

                bookList.Add(book);
            }

            context.Books.AddRange(bookList);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var authorsDtos = JsonConvert.DeserializeObject<ImportAuthorsDTO[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            List<Author> authorsList = new List<Author>();

            foreach (var authorDto in authorsDtos)
            {
                bool emailExist = authorsList.Any(a => a.Email == authorDto.Email);

                if (!IsValid(authorDto)|| emailExist)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var currAuthor = new Author()
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    Phone = authorDto.Phone,
                    Email = authorDto.Email,
                };

                foreach (var book in authorDto.Books)
                {
                    if (!context.Books.Any(b => b.Id == book.Id))
                    {
                        continue;
                    }

                    currAuthor.AuthorsBooks.Add(new AuthorBook
                    {
                        BookId = book.Id,
                    });                    
                }

                if (!currAuthor.AuthorsBooks.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                sb
                    .AppendLine(String.Format
                    (SuccessfullyImportedAuthor, $"{authorDto.FirstName} {authorDto.LastName}", currAuthor.AuthorsBooks.Count));

                authorsList.Add(currAuthor);
            }

            context.Authors.AddRange(authorsList);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}