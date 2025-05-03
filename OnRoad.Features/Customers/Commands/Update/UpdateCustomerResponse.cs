namespace OnRoad.Features.Customers.Commands.Update;

public record UpdateCustomerResponse(Guid Id, string FullName, DateOnly BirthDate, string DocumentTax);