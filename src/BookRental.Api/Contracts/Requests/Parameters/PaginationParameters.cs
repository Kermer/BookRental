namespace BookRental.Api.Contracts.Requests.Parameters;

public sealed class PaginationParameters
{
    public int Page { get; init; } = 1;
    public int PerPage { get; init; } = 20;
}
