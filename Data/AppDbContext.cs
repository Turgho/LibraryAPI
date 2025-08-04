using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace BibliotecaAPI.Database;

public class AppDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}