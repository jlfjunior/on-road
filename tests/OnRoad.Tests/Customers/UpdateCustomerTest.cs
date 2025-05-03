using System.Net.Http.Json;
using Bogus;
using Bogus.Extensions.Brazil;
using Microsoft.Extensions.DependencyInjection;
using OnRoad.Domain.Entities;
using OnRoad.Features.Customers.Commands.Update;
using OnRoad.Infrastructure.Repositories;

namespace OnRoad.Tests.Customers;

public class UpdateCustomerTest : BaseTest
{
    public UpdateCustomerTest(CustomWebApplicationFactory<Program> factory)
     : base(factory) { }
    
    [Fact]
    public async Task UpdateCustomer_Successfully_WhenCustomerExistAsync()
    {
        var repository = Factory.Services.GetRequiredService<IRepository<Customer>>();

        var faker = new Faker<Customer>()
            .CustomInstantiator(c 
                => new Customer(fullName: c.Person.FullName, c.Person.Cpf(), c.Date.PastDateOnly())
                ).Generate();
        
        await repository.StoreAsync(faker);
        var command = new UpdateCustomerRequest("José Junior");
        
        var response = await HttpClient.PutAsJsonAsync($"/customers/{faker.Id}", command);

        response.EnsureSuccessStatusCode();
    }
    
    [Fact]
    public async Task UpdateCustomer_ShouldReturnBadRequest_WhenCustomerNotExistAsync()
    {
        var command = new UpdateCustomerRequest("José Junior");
        
        var response = await HttpClient.PutAsJsonAsync($"/customers/{Guid.NewGuid()}", command);

        Assert.Equal(400, (int)response.StatusCode);
    }
}