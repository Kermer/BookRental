namespace BookRental.Api.Contracts.Responses;

public class BooksResponse
{
    public required IEnumerable<BookResponse> Items { get; init; } = [];
}
