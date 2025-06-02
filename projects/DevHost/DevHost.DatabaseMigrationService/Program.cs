using DevHost.DatabaseMigrationService;
using Infrastructure;
using Infrastructure.SqlMigrations;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);
builder.AddServiceDefaults();
builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(Worker.ActivitySourceName));
builder.Services.AddDbContext<DatabaseContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("sqldatabase"),
    c => c.MigrationsAssembly(typeof(DatabaseContextFactory).Assembly)));

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
