using Infrastructure;
using Riok.Mapperly.Abstractions;
using WebApi.Dtos;

namespace WebApi.Mappers;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
internal static partial class CategoryMapper
{
    internal static partial Category ToDto(this TransactionCategory transactionCategory);
    internal static partial ICollection<Category> ToDtos(this IEnumerable<TransactionCategory> transactionCategories);
}