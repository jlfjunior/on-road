namespace OnRoad.Application.Customers.Commands.Create;

public record CreateCustomerResponse(Guid Id, string FullName, DateOnly BirthDate, string DocumentTax);