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
    public bool IsDefault { get; set; } = false;
    public TransactionCategoryType Type { get; set; } = TransactionCategoryType.Expense;
    [JsonIgnore]
    public ICollection<Transaction>? Transactions { get; set; }
    public long? ParentTransactionCategoryId { get; set; }
    [JsonIgnore]
    public TransactionCategory? ParentCategory { get; set; }
    [JsonIgnore]
    public ICollection<TransactionCategory>? ChildCategories { get; set; }
}

public class Rule
{
    public long Id { get; set; }
    public int OrderNumber { get; set; }
    public ICollection<RuleCondition>? Conditions { get; set; }
    public ICollection<RuleAction>? Actions { get; set; }
    public bool StopAfter { get; set; }
}

public abstract class RuleCondition
{
    public long Id { get; set; }
    public long RuleId { get; set; }
    public Rule? Rule { get; set; }
}
public enum AmountIs
{
    Equal,
    LessThan,
    GreaterThan,
    EqualLessThan,
    GreaterThanEqual
}
public class RuleAmountIsCondition: RuleCondition
{
    

    public AmountIs AmountIs { get; set; } = AmountIs.Equal;
    public decimal Value { get; set; }
}

public abstract class RuleAction
{
    public long Id { get; set; }
    public long RuleId { get; set; }
    public Rule? Rule { get; set; }
}

public class RuleSetCategoryAction:RuleAction
{
    public long CategoryId { get; set; }
    public TransactionCategory? Category { get; set; }
}

public class DatabaseContext : DbContext
{
    public DatabaseContext(){}
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    
    public DbSet<TransactionAccount> TransactionAccounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<TransactionCategory> TransactionCategories { get; set; }
    
    public DbSet<Rule> Rules { get; set; }
    public DbSet<RuleCondition> RuleConditions { get; set; }
    public DbSet<RuleAmountIsCondition> RuleAmountIsConditions { get; set; }
    public DbSet<RuleAction> RuleActions { get; set; }
    public DbSet<RuleSetCategoryAction> RuleSetCategoryActions { get; set; }
}