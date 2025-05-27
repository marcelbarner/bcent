using Infrastructure;

namespace DevHost.DatabaseDataSeeder;

public static class TransactionAccounts
{
    public static readonly TransactionAccount CheckingAccount = new()
    {
        Id = 1,
        Name = "Checking Account"
    };
}