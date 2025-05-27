using DevHost.DatabaseDataSeeder;
using Infrastructure;
using Riok.Mapperly.Abstractions;
using WebApi.Endpoints;

namespace WebApi.Mappers;

[Mapper]
internal static partial class DashboardMapper
{
    internal static DashboardEndpoints.DashboardKpis ToDashboardKpis(this ICollection<Transaction> transactions)
        => new()
        {
            TotalAssets = transactions.Sum(c => c.Amount),
            TotalLiabilities = 0
        };
    
    internal static DashboardEndpoints.IncomeVsExpenses ToDashboardIncomeVsExpenses(this ICollection<Transaction> transactions)
        => new()
        {
            Income = transactions.Where(c => c.Amount > 0).Sum(c => c.Amount),
            Expenses = transactions.Where(c => c.Amount < 0).Sum(c => c.Amount)
        };

    internal static IEnumerable<DashboardEndpoints.Category> ToDashboardCashflowItems(
        this IQueryable<TransactionCategory> categories)
        => categories.Select(c => new DashboardEndpoints.Category()
        {
            Id = c.Id,
            Name = c.Name,
            ParentId = c.ParentTransactionCategoryId,
            ParentName = c.ParentCategory != null ? c.ParentCategory!.Name : null,
            Value = c.CategoryValue(),
            Type = c.Type
        });

    internal static decimal CategoryValue(this TransactionCategory category)
        => category.DirektValue() + category.ChildValue();
    internal static decimal DirektValue(this TransactionCategory category)
        => category.Transactions.Sum(c => c.Amount);

    internal static decimal ChildValue(this TransactionCategory category)
        => category.ChildCategories.Select(c => c.CategoryValue()).Sum();
}