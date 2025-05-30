using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace WebApi2.Features.Dashboard.History.TotalNetWorth;

sealed class HistoryTotalNetWorthEndpoint(DatabaseContext databaseContext)
    : Endpoint<DashboardRequest, IReadOnlyList<DashboardHistoryItem>>
{
    public override void Configure()
    {
        Get("dashboard/history/total-net-worth");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DashboardRequest req, CancellationToken ct)
    {
        var dailySums = await databaseContext.Set<Transaction>().GroupBy(c => c.Date).Select(c => new {Date = c.Key, Value = c.Sum(x => x.Amount)})
            .ToDictionaryAsync(x => x.Date, x => x.Value, ct);

        var startValue = req.From is null ? 0 : dailySums.Where(c => c.Key < req.From.Value).Sum(c => c.Value);
        var calculationDate = req.From ?? dailySums.Min(c => c.Key);
        var totalNetWorths = new List<DashboardHistoryItem>();
        while (calculationDate <= DateOnly.FromDateTime(DateTime.UtcNow))
        {
            dailySums.TryGetValue(calculationDate, out decimal dailySum);
            startValue += dailySum;
            totalNetWorths.Add(new DashboardHistoryItem(calculationDate, startValue));
            calculationDate = calculationDate.AddDays(1);
        }

        await SendAsync(totalNetWorths, cancellation: ct);
    }
}