using Infrastructure;
using Microsoft.EntityFrameworkCore;
using WebApi2.Features.Dashboard.History;

namespace WebApi2.Features.Dashboard.Cashflow;

sealed class CashflowEndpoint(DatabaseContext databaseContext)
    : Endpoint<DashboardRequest, IReadOnlyList<CashFlowItem>>
{
    public override void Configure()
    {
        Get("dashboard/cash-flow");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DashboardRequest req, CancellationToken ct)
    {
        var x = req.From is null
            ? await databaseContext.TransactionCategories.ToItems().ToListAsync(ct)
            : await databaseContext.TransactionCategories.Select(c => new CategoryItem()
            {
                Id = c.Id,
                Type = c.Type,
                ParentId = c.ParentTransactionCategoryId,
                Amount = c.CategoryValueInPeriod(req.From.Value)
            }).ToListAsync(ct);
        var result = new List<CashFlowItem>();
        foreach (var item in x.Where(x => x.ParentId is not null))
        {
            var cashflowItem =item.Type == TransactionCategoryType.Income ?
                new CashFlowItem(item.Id.ToString(), item.ParentId?.ToString() ?? "income", GetAggregatedCategoryValue(item, x))
                : new CashFlowItem(item.ParentId?.ToString() ?? "expense", item.Id.ToString() , -1*GetAggregatedCategoryValue(item, x));
            result.Add(cashflowItem);
        }

        var expenseCategory = x.First(c => c.ParentId is null && c.Type == TransactionCategoryType.Expense);
        var incomeCategory = x.First(c => c.ParentId is null && c.Type == TransactionCategoryType.Income);
        var expenses = -1*GetAggregatedCategoryValue(expenseCategory, x);
        var incomes = GetAggregatedCategoryValue(incomeCategory, x);
        result.Add(new CashFlowItem(incomeCategory.Id.ToString(), expenseCategory.Id.ToString(), Math.Min(expenses, incomes)));
        result = result.Where(c => c.Amount != 0).ToList();
        
        await SendAsync(result, cancellation: ct);
    }

    private decimal GetAggregatedCategoryValue(CategoryItem item, List<CategoryItem> p1)
    {
        var children = p1.Where(c => c.ParentId == item.Id).ToList();
        return item.Amount + children.Sum(x => GetAggregatedCategoryValue(x, p1));
    }
}