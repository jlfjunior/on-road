using MongoDB.Driver;
using OnRoad.Customers.API.Domain;

namespace OnRoad.Customers.API;

public class CustomerService : ICustomerService
{
    private readonly IMongoCollection<Customer> _collection;

    public CustomerService(IMongoDatabase database)
    {
        _collection = database.GetCollection<Customer>("customers");
    }
    
    public async Task<IEnumerable<Customer>> AllAsync()
    {
        var customers = await _collection.FindAsync(customer => true);

        return customers.ToList();
    }

    public async Task<Customer> AddAsync(string fullName, string documentTax, DateOnly birthDate)
    {
        var customer = new Customer(fullName, documentTax, birthDate);
        await _collection.InsertOneAsync(customer);
        return customer;
    }

    public async Task DeleteAsync(Guid customerId)
    {
        var filter = Builders<Customer>.Filter.Eq(x => x.Id, customerId);
        await _collection.DeleteOneAsync(filter);    
    }
}