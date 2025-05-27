using Infrastructure;

namespace DevHost.DatabaseDataSeeder;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}

public static class TransactionSamples
{
    public static readonly Transaction[] All = new Transaction[]
    {
        // Monthly: Salary (Income)
        new()
        {
            Id = 1, PurposeOfUse = "Monthly Salary", Amount = 3200.00m, Date = new DateOnly(2024, 1, 30),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.Salary.Id
        },
        new()
        {
            Id = 2, PurposeOfUse = "Monthly Salary", Amount = 3200.00m, Date = new DateOnly(2024, 2, 29),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.Salary.Id
        },
        new()
        {
            Id = 3, PurposeOfUse = "Monthly Salary", Amount = 3200.00m, Date = new DateOnly(2024, 3, 29),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.Salary.Id
        },
        new()
        {
            Id = 4, PurposeOfUse = "Monthly Salary", Amount = 3200.00m, Date = new DateOnly(2024, 4, 30),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.Salary.Id
        },
        new()
        {
            Id = 5, PurposeOfUse = "Monthly Salary", Amount = 3200.00m, Date = new DateOnly(2024, 5, 31),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.Salary.Id
        },
        new()
        {
            Id = 6, PurposeOfUse = "Monthly Salary", Amount = 3200.00m, Date = new DateOnly(2024, 6, 28),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.Salary.Id
        },
        new()
        {
            Id = 7, PurposeOfUse = "Monthly Salary", Amount = 3200.00m, Date = new DateOnly(2024, 7, 31),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.Salary.Id
        },
        new()
        {
            Id = 8, PurposeOfUse = "Monthly Salary", Amount = 3200.00m, Date = new DateOnly(2024, 8, 30),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.Salary.Id
        },
        new()
        {
            Id = 9, PurposeOfUse = "Monthly Salary", Amount = 3200.00m, Date = new DateOnly(2024, 9, 30),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.Salary.Id
        },
        new()
        {
            Id = 10, PurposeOfUse = "Monthly Salary", Amount = 3200.00m, Date = new DateOnly(2024, 10, 31),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.Salary.Id
        },
        new()
        {
            Id = 11, PurposeOfUse = "Monthly Salary", Amount = 3200.00m, Date = new DateOnly(2024, 11, 29),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.Salary.Id
        },
        new()
        {
            Id = 12, PurposeOfUse = "Monthly Salary", Amount = 3200.00m, Date = new DateOnly(2024, 12, 30),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.Salary.Id
        },

        // Monthly: Rent
        new()
        {
            Id = 13, PurposeOfUse = "Monthly Rent", Amount = -950.00m, Date = new DateOnly(2024, 1, 3),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.Rent.Id
        },
        new()
        {
            Id = 14, PurposeOfUse = "Monthly Rent", Amount = -950.00m, Date = new DateOnly(2024, 2, 3),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.Rent.Id
        },
        new()
        {
            Id = 15, PurposeOfUse = "Monthly Rent", Amount = -950.00m, Date = new DateOnly(2024, 3, 3),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.Rent.Id
        },
        new()
        {
            Id = 16, PurposeOfUse = "Monthly Rent", Amount = -950.00m, Date = new DateOnly(2024, 4, 3),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.Rent.Id
        },
        new()
        {
            Id = 17, PurposeOfUse = "Monthly Rent", Amount = -950.00m, Date = new DateOnly(2024, 5, 3),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.Rent.Id
        },
        new()
        {
            Id = 18, PurposeOfUse = "Monthly Rent", Amount = -950.00m, Date = new DateOnly(2024, 6, 3),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.Rent.Id
        },
        new()
        {
            Id = 19, PurposeOfUse = "Monthly Rent", Amount = -950.00m, Date = new DateOnly(2024, 7, 3),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.Rent.Id
        },
        new()
        {
            Id = 20, PurposeOfUse = "Monthly Rent", Amount = -950.00m, Date = new DateOnly(2024, 8, 3),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.Rent.Id
        },
        new()
        {
            Id = 21, PurposeOfUse = "Monthly Rent", Amount = -950.00m, Date = new DateOnly(2024, 9, 3),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.Rent.Id
        },
        new()
        {
            Id = 22, PurposeOfUse = "Monthly Rent", Amount = -950.00m, Date = new DateOnly(2024, 10, 3),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.Rent.Id
        },
        new()
        {
            Id = 23, PurposeOfUse = "Monthly Rent", Amount = -950.00m, Date = new DateOnly(2024, 11, 3),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.Rent.Id
        },
        new()
        {
            Id = 24, PurposeOfUse = "Monthly Rent", Amount = -950.00m, Date = new DateOnly(2024, 12, 3),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.Rent.Id
        },

        // ... continued for each month

        // Monthly: Pension Insurance
        new()
        {
            Id = 25, PurposeOfUse = "Pension Insurance", Amount = -300.00m, Date = new DateOnly(2024, 1, 10),
            AccountId = TransactionAccounts.CheckingAccount.Id,
            TransactionCategoryId = TransactionCategories.Pension.Id
        },
        new()
        {
            Id = 26, PurposeOfUse = "Pension Insurance", Amount = -300.00m, Date = new DateOnly(2024, 2, 10),
            AccountId = TransactionAccounts.CheckingAccount.Id,
            TransactionCategoryId = TransactionCategories.Pension.Id
        },
        new()
        {
            Id = 27, PurposeOfUse = "Pension Insurance", Amount = -300.00m, Date = new DateOnly(2024, 3, 10),
            AccountId = TransactionAccounts.CheckingAccount.Id,
            TransactionCategoryId = TransactionCategories.Pension.Id
        },
        new()
        {
            Id = 28, PurposeOfUse = "Pension Insurance", Amount = -300.00m, Date = new DateOnly(2024, 4, 10),
            AccountId = TransactionAccounts.CheckingAccount.Id,
            TransactionCategoryId = TransactionCategories.Pension.Id
        },
        new()
        {
            Id = 29, PurposeOfUse = "Pension Insurance", Amount = -300.00m, Date = new DateOnly(2024, 5, 10),
            AccountId = TransactionAccounts.CheckingAccount.Id,
            TransactionCategoryId = TransactionCategories.Pension.Id
        },
        new()
        {
            Id = 30, PurposeOfUse = "Pension Insurance", Amount = -300.00m, Date = new DateOnly(2024, 6, 10),
            AccountId = TransactionAccounts.CheckingAccount.Id,
            TransactionCategoryId = TransactionCategories.Pension.Id
        },
        new()
        {
            Id = 31, PurposeOfUse = "Pension Insurance", Amount = -300.00m, Date = new DateOnly(2024, 7, 10),
            AccountId = TransactionAccounts.CheckingAccount.Id,
            TransactionCategoryId = TransactionCategories.Pension.Id
        },
        new()
        {
            Id = 32, PurposeOfUse = "Pension Insurance", Amount = -300.00m, Date = new DateOnly(2024, 8, 10),
            AccountId = TransactionAccounts.CheckingAccount.Id,
            TransactionCategoryId = TransactionCategories.Pension.Id
        },
        new()
        {
            Id = 33, PurposeOfUse = "Pension Insurance", Amount = -300.00m, Date = new DateOnly(2024, 9, 10),
            AccountId = TransactionAccounts.CheckingAccount.Id,
            TransactionCategoryId = TransactionCategories.Pension.Id
        },
        new()
        {
            Id = 34, PurposeOfUse = "Pension Insurance", Amount = -300.00m, Date = new DateOnly(2024, 10, 10),
            AccountId = TransactionAccounts.CheckingAccount.Id,
            TransactionCategoryId = TransactionCategories.Pension.Id
        },
        new()
        {
            Id = 35, PurposeOfUse = "Pension Insurance", Amount = -300.00m, Date = new DateOnly(2024, 11, 10),
            AccountId = TransactionAccounts.CheckingAccount.Id,
            TransactionCategoryId = TransactionCategories.Pension.Id
        },
        new()
        {
            Id = 36, PurposeOfUse = "Pension Insurance", Amount = -300.00m, Date = new DateOnly(2024, 12, 10),
            AccountId = TransactionAccounts.CheckingAccount.Id,
            TransactionCategoryId = TransactionCategories.Pension.Id
        },
        // ... up to December

        // Monthly: Investment in ETFs
        new()
        {
            Id = 37, PurposeOfUse = "Monthly ETF investment", Amount = -200.00m, Date = new DateOnly(2024, 1, 15),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.ETFsFunds.Id
        },
        new()
        {
            Id = 38, PurposeOfUse = "Monthly ETF investment", Amount = -200.00m, Date = new DateOnly(2024, 2, 15),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.ETFsFunds.Id
        },
        new()
        {
            Id = 39, PurposeOfUse = "Monthly ETF investment", Amount = -200.00m, Date = new DateOnly(2024, 3, 15),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.ETFsFunds.Id
        },
        new()
        {
            Id = 40, PurposeOfUse = "Monthly ETF investment", Amount = -200.00m, Date = new DateOnly(2024, 4, 15),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.ETFsFunds.Id
        },
        new()
        {
            Id = 41, PurposeOfUse = "Monthly ETF investment", Amount = -200.00m, Date = new DateOnly(2024, 5, 15),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.ETFsFunds.Id
        },
        new()
        {
            Id = 42, PurposeOfUse = "Monthly ETF investment", Amount = -200.00m, Date = new DateOnly(2024, 6, 15),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.ETFsFunds.Id
        },
        new()
        {
            Id = 43, PurposeOfUse = "Monthly ETF investment", Amount = -200.00m, Date = new DateOnly(2024, 7, 15),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.ETFsFunds.Id
        },
        new()
        {
            Id = 44, PurposeOfUse = "Monthly ETF investment", Amount = -200.00m, Date = new DateOnly(2024, 8, 15),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.ETFsFunds.Id
        },
        new()
        {
            Id = 45, PurposeOfUse = "Monthly ETF investment", Amount = -200.00m, Date = new DateOnly(2024, 9, 15),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.ETFsFunds.Id
        },
        new()
        {
            Id = 46, PurposeOfUse = "Monthly ETF investment", Amount = -200.00m, Date = new DateOnly(2024, 10, 15),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.ETFsFunds.Id
        },
        new()
        {
            Id = 47, PurposeOfUse = "Monthly ETF investment", Amount = -200.00m, Date = new DateOnly(2024, 11, 15),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.ETFsFunds.Id
        },
        new()
        {
            Id = 48, PurposeOfUse = "Monthly ETF investment", Amount = -200.00m, Date = new DateOnly(2024, 12, 15),
            AccountId = TransactionAccounts.CheckingAccount.Id, TransactionCategoryId = TransactionCategories.ETFsFunds.Id
        },
        
        // ... through December

        // Yearly: Vacation
        new()
        {
            Id = 49, PurposeOfUse = "Summer vacation booking", Amount = -1200.00m, Date = new DateOnly(2024, 6, 20),
            AccountId = TransactionAccounts.CheckingAccount.Id,
            TransactionCategoryId = TransactionCategories.Travel.Id
        },

        // Yearly: Donation
        new()
        {
            Id = 50, PurposeOfUse = "Charity donation", Amount = -150.00m, Date = new DateOnly(2024, 12, 5),
            AccountId = TransactionAccounts.CheckingAccount.Id,
            TransactionCategoryId = TransactionCategories.Donations.Id
        },

        // Yearly: Unexpected
        new()
        {
            Id = 51, PurposeOfUse = "Car repair", Amount = -500.00m, Date = new DateOnly(2024, 4, 9),
            AccountId = TransactionAccounts.CheckingAccount.Id,
            TransactionCategoryId = TransactionCategories.Car.Id
        },
        new()
        {
            Id = 52, PurposeOfUse = "Emergency dental treatment", Amount = -350.00m, Date = new DateOnly(2024, 9, 18),
            AccountId = TransactionAccounts.CheckingAccount.Id,
            TransactionCategoryId = TransactionCategories.Dental.Id
        }
    };
}