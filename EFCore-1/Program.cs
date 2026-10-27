using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        using var context = new BookstoreDbContext();

        Console.WriteLine("Checking database status...");
        bool isCreated = context.Database.EnsureCreated();

        if (isCreated)
        {
            Console.WriteLine("SUCCESS: Database 'ReadMoreBooksDb' created successfully using EF Core conventions on .NET 9.0!");
        }
        else
        {
            Console.WriteLine("Database already exists. Connected successfully.");
        }

        if (!context.Categories.Any())
        {
            var category = new Category
            {
                Name = "Classic Literature",
                Description = "Timeless literary masterpieces.",
                IsActive = true
            };

            var author = new Author
            {
                FirstName = "Jane",
                LastName = "Austen",
                Email = "jane.austen@example.com",
                Biography = "Renowned English novelist known for her realism and social commentary.",
                DateOfBirth = new DateTime(1775, 12, 16)
            };

            var book = new Book
            {
                Title = "Pride and Prejudice",
                ISBN = "978-0141439518",
                Price = 14.99m,
                PageCount = 432,
                PublishedYear = 1813,
                InStock = true,
                Category = category,
                Authors = new List<Author> { author }
            };

            context.Books.Add(book);
            context.SaveChanges();
            Console.WriteLine("\nSample bookstore data seeded successfully via conventions!");
        }

        var booksInDb = context.Books
            .Include(b => b.Category)
            .Include(b => b.Authors)
            .ToList();

        Console.WriteLine("\n--- ReadMore Books Inventory ---");
        foreach (var book in booksInDb)
        {
            var authorsList = string.Join(", ", book.Authors.Select(a => $"{a.FirstName} {a.LastName}"));
            Console.WriteLine($"[Book] Title: {book.Title}");
            Console.WriteLine($"       ISBN: {book.ISBN} | Price: ${book.Price} | Year: {book.PublishedYear}");
            Console.WriteLine($"       Category: {book.Category.Name}");
            Console.WriteLine($"       Author(s): {authorsList}");
            Console.WriteLine(new string('-', 40));
        }
    }
}