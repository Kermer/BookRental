using BookRental.Api.Models;

namespace BookRental.Api.Contracts;

internal sealed class BookStatusChange
{
    public required BookStatus CurrentStatus { get; init; }
    public required BookStatus NewStatus { get; init; }
}
