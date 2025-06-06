using System.ComponentModel.DataAnnotations;

namespace WebApi2.Features.Accounts;

public record Transaction(
    [property: Required] long AccountId,
    [property: Required] DateOnly Date,
    [property: Required] decimal Amount)
{
    public string? PurposeOfUse { get; set; }
    public long? TransactionCategoryId { get; set; }
    public long? Id { get; set; }
}