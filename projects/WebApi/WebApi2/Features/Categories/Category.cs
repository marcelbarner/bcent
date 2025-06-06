using System.ComponentModel.DataAnnotations;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace WebApi2.Features.Categories;

public record Category
{
    public long? Id { get; init; }
    public string? Name { get; init; }
    [Required]
    public TransactionCategoryType Type { get; init; }
    public long? ParentId { get; init; }
}

sealed class AccountsEndpoint(DatabaseContext databaseContext)
    : EndpointWithoutRequest<IReadOnlyList<Category>>
{
    public override void Configure()
    {
        Get("categories");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var categories = await databaseContext.Set<TransactionCategory>()
            .Select(c => new Category()
            {
                Id = c.Id,
                Name = c.Name,
                Type = c.Type,
                ParentId = c.ParentTransactionCategoryId
            }).ToListAsync(ct);

        await SendAsync(categories, cancellation: ct);
    }
}