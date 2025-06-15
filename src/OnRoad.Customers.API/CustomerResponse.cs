using OnRoad.Customers.API.Domain;

public class CustomerResponse
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string DocumentTax { get; set; }
    public DateOnly BirthDate { get; set; }

    public static CustomerResponse Map(Customer customer)
    {
        return new CustomerResponse
        {
            Id = customer.Id,
            FullName = customer.FullName,
            DocumentTax = customer.DocumentTax,
            BirthDate = customer.BirthDate
        };
    }
}