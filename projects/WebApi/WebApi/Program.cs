using DevHost.DatabaseDataSeeder;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using WebApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi().AddDbContext<DatabaseContext>(c => c.UseInMemoryDatabase("database"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapDashboardEndpoints()
    .MapCategoryEndpoints()
    .MapGet("", async void (DatabaseContext databaseContext, CancellationToken cancellationToken = default) =>
    {
        databaseContext.AddRange(TransactionCategories.All);
        databaseContext.Add(TransactionAccounts.CheckingAccount);
        databaseContext.AddRange(TransactionSamples.All);
        await databaseContext.SaveChangesAsync(cancellationToken);
    });
app.Run();