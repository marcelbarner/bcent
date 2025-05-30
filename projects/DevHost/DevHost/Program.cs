var builder = DistributedApplication.CreateBuilder(args);
builder.AddAzureFunctionsProject<Projects.Worker>("worker");

var sqlServer = builder.AddSqlServer("sqlserver")
    .WithLifetime(ContainerLifetime.Persistent)
    .WithDataVolume("SqlServer");
var database = sqlServer.AddDatabase("sqldatabase");

var webapi = builder.AddProject<Projects.WebApi>("webapi")
    //.WithReference(database)
    //.WaitFor(database)
    .WithExternalHttpEndpoints();

var databaseMigrationService = builder.AddProject<Projects.DevHost_DatabaseMigrationService>("DatabaseMigrationService")
    .WithReference(database)
    .WaitFor(database);

var databaseDataSeeder = builder.AddProject<Projects.DevHost_DatabaseDataSeeder>("DatabaseDataSeeder")
    .WithReference(database)
    .WaitFor(database)
    .WithExplicitStart();

builder.AddNpmApp("webapp", "../../WebApp")
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .WithReference(webapi)
    .WaitFor(webapi);
builder.Build().Run();