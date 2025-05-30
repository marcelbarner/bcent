using Microsoft.AspNetCore.Mvc;

namespace WebApi2.Features.Dashboard;

public record DashboardRequest{
    [Microsoft.AspNetCore.Mvc.FromQuery]
    public DateOnly? From { get; set; }
}