using EntityFrameworkCore.Projectables;
using Infrastructure;
using Riok.Mapperly.Abstractions;

namespace WebApi2.Features.Accounts;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public static partial class AccountMapper
{
    [Projectable(NullConditionalRewriteSupport = NullConditionalRewriteSupport.Ignore)]
    public static decimal GetAccountValue(this TransactionAccount account)
        => account.Transactions!.Sum(c => c.Amount);
    [Projectable(NullConditionalRewriteSupport = NullConditionalRewriteSupport.Ignore)]
    public static decimal GetAccountValueUntil(this TransactionAccount account, DateOnly date)
        => account.Transactions!.Where(c => c.Date < date).Sum(c => c.Amount);
}