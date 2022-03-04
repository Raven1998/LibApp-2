using System;
using System.Linq;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                context.Database.EnsureCreated();
                if (context.MembershipTypes.Any() && context.Genre.Any() && context.Customers.Any() && context.Books.Any())
                {
                    Console.WriteLine("Database already seeded");
                    return;
                }

                context.MembershipTypes.AddRange(
                new MembershipType
                {
                    Id = 1,
                    SignUpFee = 0,
                    DurationInMonths = 0,
                    DiscountRate = 0,
                    Name = "Pay as You GO"
                },
                new MembershipType
                {
                    Id = 2,
                    SignUpFee = 30,
                    DurationInMonths = 1,
                    DiscountRate = 10,
                    Name = "Monthly"
                },
                new MembershipType
                {
                    Id = 3,
                    SignUpFee = 90,
                    DurationInMonths = 3,
                    DiscountRate = 15,
                    Name = "Quaterly"
                },
                new MembershipType
                {
                    Id = 4,
                    SignUpFee = 300,
                    DurationInMonths = 12,
                    DiscountRate = 20,
                    Name = "Yearly"
                });

              

                context.Customers.AddRange(
                new Customer
                {
                    Name = "Rafal Kruczkowski",
                    Birthdate = new DateTime(1998, 3, 6),
                    HasNewsletterSubscribed = true,
                    MembershipTypeId = 1
                },
                new Customer
                {
                    Name = "Zbigniew Stonoga",
                    Birthdate = new DateTime(1992, 1, 4),
                    HasNewsletterSubscribed = false,
                    MembershipTypeId = 2
                },
                new Customer
                {
                    Name = "Hasbulla Magomedov",
                    Birthdate = new DateTime(2002, 5, 9),
                    HasNewsletterSubscribed = false,
                    MembershipTypeId = 2,
                });

                context.Books.AddRange(
                new Book
                {
                    ReleaseDate = new DateTime(2000, 1, 1),
                    AuthorName = "Andrzej Sapkowski",
                    GenreId = 6,
                    Name = "Wiedzmin",
                    NumberInStock = 15,
                },
                new Book
                {
                    ReleaseDate = new DateTime(1998, 2, 3),
                    AuthorName = "Steven Hawking",
                    GenreId = 1,
                    Name = "Scooby Doo",
                    NumberInStock = 9,
                },
                new Book
                {
                    ReleaseDate = new DateTime(1996, 3, 12),
                    AuthorName = "Jason Statham",
                    GenreId = 1,
                    Name = "Die Hard",
                    NumberInStock = 13,
                });
                context.SaveChanges();
            }
        }
    }
}