using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace WebApi2.Features.Accounts;

sealed class AccountsEndpoint(DatabaseContext databaseContext)
    : EndpointWithoutRequest<IReadOnlyList<Account>>
{
    public override void Configure()
    {
        Get("accounts");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var accounts = await databaseContext.Set<TransactionAccount>()
            .Select(c => new Account
            {
                Id = c.Id,
                Name = c.Name
            }).ToListAsync(ct);

        await SendAsync(accounts, cancellation: ct);
    }
}