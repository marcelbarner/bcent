var builder = DistributedApplication.CreateBuilder(args);
builder.AddAzureFunctionsProject<Projects.Worker>("worker");
var webapi = builder.AddProject<Projects.WebApi>("webapi");
builder.AddNpmApp("webapp", "../../WebApp")
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .WithReference(webapi)
    .WaitFor(webapi);
builder.Build().Run();