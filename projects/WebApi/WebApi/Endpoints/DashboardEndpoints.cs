namespace WebApi.Endpoints;

internal static class DashboardEndpoints
{
    private record DashboardKpis
    {
        public decimal? TotalAssets { get; init; }
        public decimal? TotalLiabilities { get; init; }
        public decimal? NetWorth { get; init; }
    }
    internal static IEndpointRouteBuilder MapDashboardEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("api/dashboard");
        group.MapGet("kpis", () => new DashboardKpis()
            {
                TotalAssets = 100000,
                TotalLiabilities = 20000,
                NetWorth = 80000
            })
            .Produces<DashboardKpis>();
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