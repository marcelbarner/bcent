using DevHost.DatabaseDataSeeder;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using WebApi.Mappers;

namespace WebApi.Endpoints;

internal static class DashboardEndpoints
{
    internal record DashboardKpis
    {
        public decimal? TotalAssets { get; init; }
        public decimal? TotalLiabilities { get; init; }
        public decimal? NetWorth => TotalAssets + TotalLiabilities;
    }

    internal record IncomeVsExpenses
    {
        public decimal? Income { get; init; }
        public decimal? Expenses { get; init; }
        public decimal? Difference => Income + Expenses;
    }

    internal record Category
    {
        public long Id { get; init; }
        public long? ParentId { get; init; }
        public TransactionCategoryType Type { get; init; }
        public string? Name { get; init; }
        public string? ParentName { get; init; }
        public decimal Value { get; init; }
    }
    internal static IEndpointRouteBuilder MapDashboardEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("api/dashboard");
        group.MapGet("kpis", () => TransactionSamples.All.ToDashboardKpis())
            .Produces<DashboardKpis>();
        group.MapGet("income-vs-expenses", () => TransactionSamples.All.ToDashboardIncomeVsExpenses())
            .Produces<IncomeVsExpenses>();
        group.MapGet("categories", async (DatabaseContext databaseContext) =>
            {
                var a = (await databaseContext.TransactionCategories.Include(x => x.Transactions)
                    .Include(c => c.ChildCategories).ToListAsync()).AsQueryable().ToDashboardCashflowItems();
                return a;
            })
            .Produces<IEnumerable<Category>>();
        group.MapGet("history/net-worth", () =>
        {
            var result = new Dictionary<DateOnly, decimal>();
            DateOnly endDate = DateOnly.FromDateTime(DateTime.Today);
            DateOnly startDate = endDate.AddYears(-3);
            Random rand = new Random();

            decimal currentValue = 100_000m; // Starting value

            for (DateOnly date = startDate; date <= endDate; date = date.AddDays(1))
            {
                // Simulate a daily change between -2% and +2%
                decimal dailyChangePercent = (decimal)(rand.NextDouble() * 4.0 - 2.0); // -2.0% to +2.0%
                decimal changeAmount = currentValue * dailyChangePercent / 100m;
                currentValue += changeAmount;

                // Ensure the value doesn't drop below zero
                if (currentValue < 0)
                    currentValue = 0;

                result[date] = Math.Round(currentValue, 2);
            }

            return result;
        }).Produces<IDictionary<DateOnly, decimal>>();
        return endpoints;
    }
}