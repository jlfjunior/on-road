namespace OnRoad.Features.Customers.Commands.Create;

public record CreateCustomerResponse(Guid Id, string FullName, DateOnly BirthDate, string DocumentTax);