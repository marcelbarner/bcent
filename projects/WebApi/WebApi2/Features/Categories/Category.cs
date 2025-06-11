using System.ComponentModel.DataAnnotations;
using Infrastructure;

namespace WebApi2.Features.Categories;

public record Category
{
    public long? Id { get; init; }
    public string? Name { get; init; }
    [Required]
    public TransactionCategoryType Type { get; init; }
    public long? ParentId { get; init; }
}