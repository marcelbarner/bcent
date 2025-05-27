using DevHost.DatabaseDataSeeder;
using WebApi.Dtos;
using WebApi.Mappers;

namespace WebApi.Endpoints;

internal static class CategoryEndpoints
{
    internal static IEndpointRouteBuilder MapCategoryEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("api/categories");
        group.MapGet("", () => TransactionCategories.All.ToDtos())
            .Produces<IEnumerable<Category>>();
        return endpoints;
    }
}