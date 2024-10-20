using BookRental.Api.Models;

namespace BookRental.Api.Contracts.Requests;

public class CreateOrUpdateBookRequest
{
    public required string Title { get; init; }
    public required string Author { get; init; }
    public required string ISBN { get; init; }
    public required BookStatus Status { get; init; }
}
