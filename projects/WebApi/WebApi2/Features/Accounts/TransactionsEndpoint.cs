using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace WebApi2.Features.Accounts;

public record TransactionsRequest
{
    public DateOnly? From { get; init; }
    public DateOnly? To { get; init; }
    public long? CategoryId { get; init; }
    public long? AccountId { get; init; }
    public string? Search { get; init; }
}

sealed class TransactionsEndpoint(DatabaseContext databaseContext)
    : Endpoint<TransactionsRequest,IReadOnlyList<Transaction>>
{
    public override void Configure()
    {
        Get("accounts/transactions");
        AllowAnonymous();
    }

    public override async Task HandleAsync(TransactionsRequest req, CancellationToken ct)
    {
        var query = databaseContext.Set<Infrastructure.Transaction>().AsQueryable();
        if (req.From.HasValue)
        {
            query = query.Where(c => c.Date >= req.From.Value);
        }

        if (req.To.HasValue)
        {
            query = query.Where(c => c.Date <= req.To.Value);
        }

        if (req.CategoryId.HasValue)
        {
            query = query.Where(c => c.TransactionCategoryId == req.CategoryId.Value);
        }

        if (req.AccountId.HasValue)
        {
            query = query.Where(c => c.AccountId == req.AccountId.Value);
        }

        if (req.Search is not null)
        {
            query = query.Where(c => c.PurposeOfUse != null && c.PurposeOfUse!.ToLower().Contains(req.Search.ToLower()) == true);
        }
        var transactions = await query.OrderByDescending(c => c.Date)
            .Select(c => new Transaction(c.AccountId, c.Date, c.Amount)
            {
                Id = c.Id,
                PurposeOfUse = c.PurposeOfUse,
                TransactionCategoryId = c.TransactionCategoryId
            }).ToListAsync(ct);

        await SendAsync(transactions, cancellation: ct);
    }
}