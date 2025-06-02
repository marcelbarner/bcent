using System.ComponentModel.DataAnnotations;

namespace WebApi2.Features.Dashboard.IncomeVsExpense;

public record DashboardIncomeVsExpense([property:Required]decimal Income, [property:Required]decimal Expense)
{
    [Required]
    public decimal Difference => Income - Expense;
};