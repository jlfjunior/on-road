using OnRoad.Customers.API.Domain;

namespace OnRoad.Customers.API;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> AllAsync();
    Task<Customer> AddAsync(string fullName, string documentTax, DateOnly birthDate);
    Task DeleteAsync(Guid customerId);
}