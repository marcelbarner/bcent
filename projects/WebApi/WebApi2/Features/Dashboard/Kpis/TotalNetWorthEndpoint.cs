using Infrastructure;
using Microsoft.EntityFrameworkCore;
using WebApi2.Features.Accounts;

namespace WebApi2.Features.Dashboard.Kpis;

sealed class TotalNetWorthEndpoint(DatabaseContext databaseContext) : Endpoint<DashboardRequest, DashboardKpi>
{
    public override void Configure()
    {
        Get("dashboard/kpis/total-net-worth");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DashboardRequest req, CancellationToken ct)
    {
        var oldAccountValues = req.From is null
            ? 0
            : await databaseContext.Set<TransactionAccount>().Select(c => c.GetAccountValueUntil(req.From.Value))
                .SumAsync(ct);
        var currentAccountValues = await databaseContext.Set<TransactionAccount>().Select(c => c.GetAccountValue())
            .SumAsync(ct);
        await SendOkAsync(new DashboardKpi(currentAccountValues, currentAccountValues - oldAccountValues), ct);
    }
}