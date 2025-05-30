using Infrastructure;

namespace WebApi2.Features.Dashboard.IncomeVsExpense;

sealed class IncomeVsExpenseEndpoint(DatabaseContext databaseContext) : Endpoint<DashboardRequest, DashboardIncomeVsExpense>
{
    public override void Configure()
    {
        Get("dashboard/income-vs-expense");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DashboardRequest req, CancellationToken ct)
    {
        var transactionsQuery = databaseContext.Set<Transaction>().AsQueryable();
        if (req.From is not null)
        {
            transactionsQuery = transactionsQuery.Where(c => c.Date >= req.From);
        }

        var income = transactionsQuery.Where(c => c.Category!.Type == TransactionCategoryType.Income)
            .Sum(c => c.Amount);
        var expense = transactionsQuery.Where(c => c.Category!.Type == TransactionCategoryType.Expense)
            .Sum(c => c.Amount);
        await SendOkAsync(new DashboardIncomeVsExpense(income, expense),ct);
    }
}