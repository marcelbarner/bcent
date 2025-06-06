using Infrastructure;

namespace WebApi2.Features.Dashboard.Cashflow;

internal class CategoryItem{
    public long Id { get; init; }
    public TransactionCategoryType Type { get; init; }
    public decimal Amount { get; init; }

    public long? ParentId { get; init; }
}