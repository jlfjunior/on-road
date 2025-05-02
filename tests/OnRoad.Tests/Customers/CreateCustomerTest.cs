using System.Net.Http.Json;
using Bogus;
using Bogus.Extensions.Brazil;
using Microsoft.Extensions.DependencyInjection;
using OnRoad.API.Features.Customers.Commands.Create;
using OnRoad.API.Infrastructure;
using OnRoad.Domain;
using OnRoad.Domain.Entities;

namespace OnRoad.Tests.Customers;

public class CreateCustomerTest : BaseTest
{
    public CreateCustomerTest(CustomWebApplicationFactory<Program> factory)
        : base(factory) { }
    
    [Fact]
    public async Task CreateCustomer_Successfully_WhenDocumentDoesNotExistsAsync()
    {
        var command = new Faker<CreateCustomerCommand>()
            .CustomInstantiator(f => new CreateCustomerCommand(
                f.Name.FullName(),
                DateOnly.FromDateTime(f.Date.Past(30, DateTime.Today.AddYears(-18))),
                f.Person.Cpf(false)
            ))
            .Generate();
        
        var response = await HttpClient.PostAsJsonAsync("/customers", command);

        response.EnsureSuccessStatusCode();
        var customer = await response.Content.ReadFromJsonAsync<CreateCustomerResponse>();
        
        Assert.Equal(201, (int)response.StatusCode);
        Assert.NotNull(customer);
        Assert.Equal(command.DocumentTax, customer.DocumentTax);
        Assert.Equal(command.BirthDate, customer.BirthDate);
        Assert.Equal(command.FullName, customer.FullName);
        
    }

    [Fact]
    public async Task CreateCustomer_ShouldReturnBadRequest_WhenDocumentExistsAsync()
    {
        var repository = Factory.Services.GetRequiredService<IRepository<Customer>>();

        var command = new Faker<CreateCustomerCommand>()
            .CustomInstantiator(f => new CreateCustomerCommand(
                f.Name.FullName(),
                DateOnly.FromDateTime(f.Date.Past(30, DateTime.Today.AddYears(-18))),
                f.Person.Cpf(false)
            ))
            .Generate();
        var customer = new Customer(command.FullName, command.DocumentTax, command.BirthDate);
        
        await repository.StoreAsync(customer);
        
        var response = await HttpClient.PostAsJsonAsync("/customers", command);
        var message = await response.Content.ReadAsStringAsync();
        
        Assert.Equal(400, (int)response.StatusCode);
        Assert.Equal($"Customer with tax {command.DocumentTax} already exists", message);
    }
}