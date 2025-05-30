using Infrastructure;
using Microsoft.EntityFrameworkCore;
using WebApi2.Features.Accounts;

namespace WebApi2.Features.Dashboard.Kpis;

sealed class TotalAssetsEndpoint(DatabaseContext databaseContext) : Endpoint<DashboardRequest, DashboardKpi>
{
    public override void Configure()
    {
        Get("dashboard/kpis/total-assets");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DashboardRequest req, CancellationToken ct)
    {
        var oldAccountValues = req.From is null
            ? 0
            : await databaseContext.Set<TransactionAccount>().Select(c => c.GetAccountValueUntil(req.From.Value))
                .Where(c => c > 0).SumAsync(ct);
        var currentAccountValues = await databaseContext.Set<TransactionAccount>().Select(c => c.GetAccountValue())
                .Where(c => c > 0).SumAsync(ct);
        await SendOkAsync(new DashboardKpi(currentAccountValues,currentAccountValues-oldAccountValues),ct);
    }
}