using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
namespace DevHost.DatabaseDataSeeder;

public class Worker(IServiceProvider serviceProvider, IHostApplicationLifetime hostApplicationLifetime) : BackgroundService
{
    public const string ActivitySourceName = "data-seeding";
    private static ActivitySource s_activitySource = new(ActivitySourceName);
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        using var activity = s_activitySource.StartActivity("Seed database", ActivityKind.Client);

        try
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

            await SeedCategoriesAsync(dbContext, cancellationToken);
            await SeedAccountsAsync(dbContext, cancellationToken);
        }
        catch (Exception ex)
        {
            activity?.AddException(ex);
            throw;
        }

        hostApplicationLifetime.StopApplication();
    }

    private async Task SeedCategoriesAsync(DatabaseContext database, CancellationToken cancellationToken)
    {
        var categoriesJson = await File.ReadAllTextAsync("data/categories.json", cancellationToken);
        var categories = JsonSerializer.Deserialize<TransactionCategory[]>(categoriesJson) ??
                         TransactionCategories.All;
        database.AddRange(categories);
        await database.SaveChangesAsync(cancellationToken);
    }
    private async Task SeedAccountsAsync(DatabaseContext database, CancellationToken cancellationToken)
    {
        var files = Directory.GetFiles("data/accounts", "*.json");
        if (files.Length != 0)
        {
            var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web)
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString
            };
            foreach (var file in files)
            {
                var accountJson = await File.ReadAllTextAsync(file, cancellationToken);
                
                var account = JsonSerializer.Deserialize<TransactionAccount>(accountJson, jsonOptions);
                if (account is not null)
                {
                    database.Add(account);
                    //var transactions = account.Transactions.Select(c =>
                    //{
                    //    c.Account = account;
                    //    return c;
                    //}).ToList();
                    //database.AddRange(transactions);
                    await database.SaveChangesAsync(cancellationToken);
                }
            }
        }
        else
        {
            database.Add(TransactionAccounts.CheckingAccount);
            database.AddRange(TransactionSamples.All);
            await database.SaveChangesAsync(cancellationToken);
        }
    }
}