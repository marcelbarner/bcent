using DevHost.DatabaseDataSeeder;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

var bld = WebApplication.CreateBuilder(args);

bld.Services
    .AddAuthenticationJwtBearer(s => s.SigningKey = bld.Configuration["Auth:JwtKey"])
    .AddAuthorization()
    .AddFastEndpoints(o => o.SourceGeneratorDiscoveredTypes = DiscoveredTypes.All)
    .SwaggerDocument()
    .AddDbContext<DatabaseContext>(options =>
    {
        options.UseSqlServer(bld.Configuration.GetConnectionString("sqldatabase"));
        options.UseProjectables();
    });

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

app.Run();