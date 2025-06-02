var builder = DistributedApplication.CreateBuilder(args);
builder.AddAzureFunctionsProject<Projects.Worker>("worker");

var sqlServer = builder.AddSqlServer("sqlserver")
    .WithLifetime(ContainerLifetime.Persistent)
    .WithDataVolume("SqlServer");
var database = sqlServer.AddDatabase("sqldatabase");

var databaseMigrationService = builder.AddProject<Projects.DevHost_DatabaseMigrationService>("DatabaseMigrationService")
    .WithReference(database)
    .WaitFor(database);

var databaseDataSeeder = builder.AddProject<Projects.DevHost_DatabaseDataSeeder>("DatabaseDataSeeder")
    .WithReference(database)
    .WaitFor(database)
    .WaitForCompletion(databaseMigrationService)
    .WithExplicitStart();

var webapi = builder.AddProject<Projects.WebApi2>("webapi")
    .WithReference(database)
    .WaitFor(database)
    .WaitForCompletion(databaseMigrationService)
    .WithExternalHttpEndpoints();

builder.AddNpmApp("webapp", "../../WebApp")
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .WithReference(webapi)
    .WaitFor(webapi);
builder.Build().Run();