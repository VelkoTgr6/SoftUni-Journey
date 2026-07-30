namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using System.Linq;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            
            
        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            if (!Enum.TryParse<AgeRestriction>(command, ignoreCase: true, out var ageRestriction))
            {
                return $"{command} is not a valid age restiction";
            }

            var books = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => new
                {
                    b.Title
                })
                .OrderBy(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => b.Title));

        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            if (!Enum.TryParse<EditionType>("Gold", out var result))
            {
                return $"ne staa";
            }

            var books = context.Books
                .Where(b => b.EditionType == result && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => b.Title));
        }
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => $"{b.Title} - ${b.Price:F2}"));
        }
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .Select(b => new
                {
                    b.BookId,
                    b.Title
                })
                .OrderBy(b => b.BookId)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => b.Title));
        }
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] inputCategories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower()).ToArray();

            var booksByCategories = context.Books
                .Where(b => b.BookCategories.Any(bc => inputCategories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, booksByCategories.Select(b => b.Title));
        }
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var parsedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var books = context.Books
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,
                    b.ReleaseDate
                })
                .Where(b => b.ReleaseDate < parsedDate)
                .OrderByDescending(b => b.ReleaseDate);

            return string.Join(Environment.NewLine, books.Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}")).TrimEnd(); ;
        }
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName

                })

                .OrderBy(a => a.FullName)
                .ToList();


            return string.Join(Environment.NewLine, authors.Select(a => a.FullName)).TrimEnd();
        }
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => new
                {
                    b.Title
                })
                .OrderBy(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => b.Title)).TrimEnd();
        }
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    AuthorName = b.Author.FirstName + " " + b.Author.LastName
                })
                .OrderBy(b => b.BookId)
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => $"{b.Title} ({b.AuthorName})")).TrimEnd();
        }
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Count(b => b.Title.Length > lengthCheck);

            return books;
        }
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var copies = context.Authors
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    TotalBooksCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(b => b.TotalBooksCopies)
                .ToList();

            return string.Join(Environment.NewLine, copies.Select(b => $"{b.AuthorName} - {b.TotalBooksCopies}")).TrimEnd();
        }
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var copies = context.Categories
                .Select(c => new
                {
                    CategoryName=c.Name,
                    TotalProfit=c.CategoryBooks.Sum(cb=>cb.Book.Copies*cb.Book.Price)
                })
                .OrderByDescending(b => b.TotalProfit)
                .ThenBy(b => b.CategoryName)
                .ToList();

            

            return string.Join(Environment.NewLine, copies.Select(b => $"{b.CategoryName} ${b.TotalProfit:F2}")).TrimEnd();
        }
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var books = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    MostRecentBooks = c.CategoryBooks.OrderByDescending(bc => bc.Book.ReleaseDate)
                    .Take(3)
                    .Select(cb => new
                    {
                        BookTitle = cb.Book.Title,
                        BookReleaseDate = cb.Book.ReleaseDate.Value.Year,
                    })
                })
                .OrderBy(b => b.CategoryName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"--{book.CategoryName}");

                foreach (var info in book.MostRecentBooks)
                {
                    sb.AppendLine($"{info.BookTitle} ({info.BookReleaseDate})");
                }
            }
                
            return sb.ToString().TrimEnd();
        }
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue &&  b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var item in books)
            {
                item.Price += 5;
            }
                
            context.SaveChanges();
            
        }
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            int counter = 0;

            foreach(var book in books)
            {
                context.Remove(book);
                counter++;
            }

            context.SaveChanges();

            return counter;

        }
    }
}


