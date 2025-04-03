using Microsoft.EntityFrameworkCore;
using OnRoad.API.Domain;
using OnRoad.API.Infrastructure;

namespace OnRoad.API.Customers;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("daily-closures");
        
        group.MapGet("/", async (Context context) =>
        {
            var customers = await context.Set<Customer>()
                .Select(c => new CustomerResponse{Id = c.Id,FullName = c.FullName })
                .ToListAsync();
            
            return Results.Ok(customers);
        }).WithDisplayName("Get daily closures");
    }
}