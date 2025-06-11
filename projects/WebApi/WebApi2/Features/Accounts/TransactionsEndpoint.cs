namespace WebApi2.Features.Accounts;

public record TransactionsRequest
{
    public DateOnly? From { get; init; }
    public DateOnly? To { get; init; }
    public long? CategoryId { get; init; }
    public long? AccountId { get; init; }
    public string? Search { get; init; }
}