namespace OnRoad.API.Features.Customers.Update;

public record UpdateCustomerResponse(Guid Id, string FullName, DateOnly BirthDate, string DocumentTax);