using DevHost.DatabaseDataSeeder;
using Infrastructure;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.AddServiceDefaults();
builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(Worker.ActivitySourceName));
builder.AddSqlServerDbContext<DatabaseContext>("sqldatabase");
var host = builder.Build();
host.Run();
