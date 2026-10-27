using System.Collections.Generic;

public class Book
{
    public int Id { get; set; } 
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int PageCount { get; set; }
    public int PublishedYear { get; set; }
    public bool InStock { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public ICollection<Author> Authors { get; set; } = new List<Author>();
}