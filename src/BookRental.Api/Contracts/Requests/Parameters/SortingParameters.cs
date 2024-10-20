namespace BookRental.Api.Contracts.Requests.Parameters;

public sealed class SortingParameters
{
    public string SortBy { get; init; } = "title";
    public string SortOrder { get; init; } = "asc";
}
