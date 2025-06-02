using System.Text.Json.Serialization;
using System.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class TransactionAccount
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Transaction>? Transactions { get; set; }
}

public class Transaction
{
    public long Id { get; set; }
    public string? PurposeOfUse { get; set; }
    public decimal Amount { get; set; }
    public DateOnly Date { get; set; }
    public long AccountId { get; set; }
    public TransactionAccount? Account { get; set; }
    public long? TransactionCategoryId { get; set; }
    public TransactionCategory? Category { get; set; }
}

public enum TransactionCategoryType
{
    Income,
    Expense
}

public class TransactionCategory
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public TransactionCategoryType Type { get; set; } = TransactionCategoryType.Expense;
    [JsonIgnore]
    public ICollection<Transaction>? Transactions { get; set; }
    public long? ParentTransactionCategoryId { get; set; }
    [JsonIgnore]
    public TransactionCategory? ParentCategory { get; set; }
    [JsonIgnore]
    public ICollection<TransactionCategory>? ChildCategories { get; set; }
}

public class DatabaseContext : DbContext
{
    public DatabaseContext(){}
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    
    public DbSet<TransactionAccount> TransactionAccounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<TransactionCategory> TransactionCategories { get; set; }
}