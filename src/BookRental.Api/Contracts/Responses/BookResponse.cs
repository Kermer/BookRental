using BookRental.Api.Models;

namespace BookRental.Api.Contracts.Responses;

public class BookResponse
{
    public required Guid Id { get; init; }
    public required string Title { get; init; }
    public required string Author { get; init; }
    public required string ISBN { get; init; }
    public required BookStatus Status { get; init; }
}
