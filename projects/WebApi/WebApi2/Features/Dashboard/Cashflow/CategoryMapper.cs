using EntityFrameworkCore.Projectables;
using Infrastructure;
using Riok.Mapperly.Abstractions;

namespace WebApi2.Features.Dashboard.Cashflow;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public static partial class CategoryMapper
{
    [Projectable(NullConditionalRewriteSupport = NullConditionalRewriteSupport.Ignore)]
    public static decimal CategoryValueInPeriod(this TransactionCategory category, DateOnly from)
        => category.Transactions!.Where(c => c.Date >= from).Sum(c => c.Amount);
    
    [Projectable(NullConditionalRewriteSupport = NullConditionalRewriteSupport.Ignore)]
    public static decimal CategoryValue(this TransactionCategory categories)
        => categories.Transactions!.Sum(c => c.Amount);

    
    [MapPropertyFromSource(nameof(CategoryItem.Amount), Use = nameof(CategoryValue))]
    [MapProperty(nameof(TransactionCategory.ParentTransactionCategoryId), nameof(CategoryItem.ParentId))]
    internal static partial CategoryItem ToItem(this TransactionCategory queryable);

    internal static partial IQueryable<CategoryItem> ToItems(this IQueryable<TransactionCategory> queryable);
}