using System.ComponentModel.DataAnnotations;

namespace WebApi2.Features.Dashboard.History;

public record DashboardHistoryItem([property:Required]DateOnly Date, [property:Required]decimal Value);