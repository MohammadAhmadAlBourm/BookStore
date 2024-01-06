using BookStore.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data;

public class BookStoreContext(DbContextOptions<BookStoreContext> options) : DbContext(options)
{

    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .Property(b => b.Id)
            .ValueGeneratedOnAdd(); // This sets the Id to be auto-generated on insert

        modelBuilder.Entity<Book>()
            .HasIndex(b => b.Id)
            .IsUnique(); // This sets the Id to be unique

        // Other configurations for your entities...

        base.OnModelCreating(modelBuilder);
    }
}
