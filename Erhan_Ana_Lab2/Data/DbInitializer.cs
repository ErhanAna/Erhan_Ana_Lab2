using Microsoft.EntityFrameworkCore;
using Erhan_Ana_Maria_Lab2.Models;

namespace Erhan_Ana_Maria_Lab2.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryContext(serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>()))
            {
                if (context.Books.Any())
                { 
                    return; // DB has previously been created
                }

                context.Authors.AddRange(
                    new Author {FirstName = "Mihail", LastName = "Sadoveanu"},
                    new Author {FirstName = "George", LastName = "Calinescu"},
                    new Author {FirstName = "Mircea", LastName = "Eliade" }
                );

                context.Books.AddRange(
                    new Book {Title = "Baltagul", Price = Decimal.Parse("22"), 
                        AuthorID = context.Authors.Single(author => author.LastName == "Sadoveanu").ID
                    },
                    new Book {Title = "Enigma Otiliei", Price = Decimal.Parse("18"),
                        AuthorID = context.Authors.Single(author => author.LastName == "Calinescu").ID
                    },
                    new Book {Title = "Maytrei", Price = Decimal.Parse("27"),
                        AuthorID = context.Authors.Single(author => author.LastName == "Eliade").ID
                    }
                );

                context.Customers.AddRange(
                    new Customer {Name = "Popescu Marcela", Address = "Str. Plopilor, nr. 24", BirthDate = DateTime.Parse("1979-09-01")},
                    new Customer {Name = "Mihailescu Cornel", Address = "Str. Bucuresti, nr. 45, ap. 2", BirthDate = DateTime.Parse("1969-07-08")}
                );

                context.SaveChanges();
            }
        }
    }
}
