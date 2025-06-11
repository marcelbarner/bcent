using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace WebApi2.Features.Categories;

sealed class DeleteCategoryEndpoint(DatabaseContext databaseContext)
    : Endpoint<DeleteRequest>
{
    public override void Configure()
    {
        Delete("categories");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteRequest req, CancellationToken ct)
    {
        var categories = await databaseContext.Set<TransactionCategory>()
            .FirstOrDefaultAsync(c => c.Id == req.Id, ct);
        if (categories is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        databaseContext.Remove(categories);
        await databaseContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}