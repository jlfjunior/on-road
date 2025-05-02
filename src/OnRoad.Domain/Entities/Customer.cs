using OnRoad.SharedKernel;

namespace OnRoad.Domain.Entities;

public class Customer : IEntity
{
    public Customer(string fullName, string documentTax, DateOnly birthDate)
    {
        Id = Guid.NewGuid();
        FullName = fullName;
        DocumentTax = documentTax;
        BirthDate = birthDate;
    }
    
    protected Customer() { }
    
    public Guid Id { get; private set; }
    public string FullName { get; private set; }
    public string DocumentTax { get; private set; }
    public DateOnly BirthDate { get; private set; }

    public void WithName(string fullName)
    {
        FullName = fullName;
    }
}