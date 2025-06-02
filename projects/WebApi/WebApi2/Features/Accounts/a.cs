using System.ComponentModel.DataAnnotations;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace WebApi2.Features.Accounts;

public record Transaction(
    [property: Required] long AccountId,
    [property: Required] DateOnly Date,
    [property: Required] decimal Amount)
{
    public string? PurposeOfUse { get; set; }
    public long? TransactionCategoryId { get; set; }
    public long? Id { get; set; }
}

sealed class TransactionsEndpoint(DatabaseContext databaseContext)
    : EndpointWithoutRequest<IReadOnlyList<Transaction>>
{
    public override void Configure()
    {
        Get("accounts/transactions");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var transactions = await databaseContext.Set<Infrastructure.Transaction>().OrderByDescending(c => c.Date)
            .Select(c => new Transaction(c.AccountId, c.Date, c.Amount)
            {
                Id = c.Id,
                PurposeOfUse = c.PurposeOfUse,
                TransactionCategoryId = c.TransactionCategoryId
            }).ToListAsync(ct);

        await SendAsync(transactions, cancellation: ct);
    }
}