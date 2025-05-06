namespace OnRoad.Application.Customers.Commands.Update;

public record UpdateCustomerResponse(Guid Id, string FullName, DateOnly BirthDate, string DocumentTax);