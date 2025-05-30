using FastEndpoints;
using Infrastructure;

namespace WebApi.Endpoints.Dashboard;

public record DashboardRequest
{
    [FromQuery]
    public DateOnly? From { get; init; }
}
public record DashboardKpi(decimal Value, decimal TrendValue);

public class TotalAssetsKpiEndpoint(DatabaseContext databaseContext): Endpoint<DashboardRequest, DashboardKpi>
{
    public override void Configure()
    {
        Post("/api/user/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DashboardRequest req, CancellationToken ct)
    {
        await SendAsync(new(10,10),cancellation:ct);
    }
}