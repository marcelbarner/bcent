using System.ComponentModel.DataAnnotations;

namespace WebApi2.Features.Dashboard.Cashflow;

public record CashFlowItem([property:Required]string From, [property:Required]string To, [property:Required]decimal Amount);