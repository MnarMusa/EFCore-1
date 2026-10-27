using Microsoft.EntityFrameworkCore;

public class BookstoreDbContext : DbContext
{
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       
        optionsBuilder.UseSqlServer("Server=.; Database=BookStoredb;Trusted_Connection=True;");
    }
}