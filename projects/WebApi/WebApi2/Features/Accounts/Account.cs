namespace WebApi2.Features.Accounts;

public record Account
{
    public long? Id { get; init; }
    public string? Name { get; set; }
};