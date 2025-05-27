using Infrastructure;

namespace WebApi.Dtos;

public record Category()
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public TransactionCategoryType Type { get; set; } = TransactionCategoryType.Expense;
    public long? ParentTransactionCategoryId { get; set; }
};