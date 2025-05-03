using System.Net.Http.Json;
using Bogus;
using Bogus.Extensions.Brazil;
using Microsoft.Extensions.DependencyInjection;
using OnRoad.API.Features.Customers.Queries.List;
using OnRoad.Domain.Entities;
using OnRoad.Infrastructure.Repositories;

namespace OnRoad.Tests.Customers;

public class ListCustomersTest : BaseTest
{
    public ListCustomersTest(CustomWebApplicationFactory<Program> factory) 
        : base(factory)  
            { }
    
    [Fact]
    public async Task ShouldListCustomers_SuccessfullyAsync()
    {
        var repository = Factory.Services.GetRequiredService<IRepository<Customer>>();

        var faker = new Faker<Customer>()
            .CustomInstantiator(c 
                => new Customer(fullName: c.Person.FullName, c.Person.Cpf(), c.Date.PastDateOnly())
            ).Generate(3);

        foreach (var customer in faker)
            await repository.StoreAsync(customer);
        
        var response = await HttpClient.GetAsync("/customers");
        
        response.EnsureSuccessStatusCode();
        var customers = await response.Content.ReadFromJsonAsync<List<CustomerResponse>>();
        
        Assert.Equal(3, customers.Count);
    }
}