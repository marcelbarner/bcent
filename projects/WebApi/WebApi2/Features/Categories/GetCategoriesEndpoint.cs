using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace WebApi2.Features.Categories;

sealed class GetCategoriesEndpoint(DatabaseContext databaseContext)
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