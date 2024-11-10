using Microsoft.EntityFrameworkCore;

namespace swc_lab3.Models;

public class BookStoreDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Genre> Genres { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost; Database=BookStoreCodeFirst; Username=postgres; Password=password");
    }
}