using DevHost.DatabaseDataSeeder;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

var bld = WebApplication.CreateBuilder(args);
bld.Services
    .AddAuthenticationJwtBearer(s => s.SigningKey = bld.Configuration["Auth:JwtKey"])
    .AddAuthorization()
    .AddFastEndpoints(o => o.SourceGeneratorDiscoveredTypes = DiscoveredTypes.All)
    .SwaggerDocument()
    .AddDbContext<DatabaseContext>(c => { c.UseInMemoryDatabase("database").UseProjectables(); });
;

var app = bld.Build();
app.UseAuthentication()
    .UseAuthorization()
    .UseFastEndpoints(c =>
    {
        c.Endpoints.RoutePrefix = "api";
        c.Binding.ReflectionCache.AddFromWebApi2();
        c.Errors.UseProblemDetails();
    })
    .UseSwaggerGen();
app.MapGet("", async void (DatabaseContext databaseContext, CancellationToken cancellationToken = default) =>
{
    databaseContext.AddRange(TransactionCategories.All);
    databaseContext.Add(TransactionAccounts.CheckingAccount);
    databaseContext.AddRange(TransactionSamples.All);
    await databaseContext.SaveChangesAsync(cancellationToken);
});
app.Run();