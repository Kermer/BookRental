using System.ComponentModel.DataAnnotations;

namespace BookRental.Api.Models;

public enum BookStatus
{
    Unknown = 0,
    OnShelf,
    Borrowed,
    Returned,
    Damaged
}

public sealed class Book
{
    [Key]
    public required Guid Id { get; init; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string ISBN { get; set; }
    public BookStatus Status { get; set; }
}
