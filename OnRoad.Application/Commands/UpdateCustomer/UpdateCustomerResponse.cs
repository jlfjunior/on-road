namespace OnRoad.Application.Commands.UpdateCustomer;

public record UpdateCustomerResponse(Guid Id, string FullName, DateOnly BirthDate, string DocumentTax);