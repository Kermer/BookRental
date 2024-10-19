using BookRental.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BookRental.Api.Data;

internal sealed class BookContext : DbContext
{
    public BookContext(DbContextOptions<BookContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
}
