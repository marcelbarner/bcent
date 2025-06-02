using System.ComponentModel.DataAnnotations;

namespace WebApi2.Features.Dashboard.Kpis;

public record DashboardKpi([property:Required]decimal TotalValue, [property:Required]decimal TrendValue);