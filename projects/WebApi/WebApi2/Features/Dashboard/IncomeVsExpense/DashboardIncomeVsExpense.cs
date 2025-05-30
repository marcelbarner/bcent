namespace WebApi2.Features.Dashboard.IncomeVsExpense;

public record DashboardIncomeVsExpense(decimal Income, decimal Expense)
{
    public decimal Difference => Income - Expense;
};