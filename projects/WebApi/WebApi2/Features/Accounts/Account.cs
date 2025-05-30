namespace WebApi2.Features.Accounts;

public record Account(long Id)
{
    public string? Name { get; set; }
    public decimal Value { get; set; }
};