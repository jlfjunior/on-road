using MediatR;
using OnRoad.Domain.Entities;
using OnRoad.Domain.Exceptions;
using OnRoad.Infrastructure.Repositories;

namespace OnRoad.API.Features.Customers.Update;

public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerResponse>
{
    readonly ILogger<UpdateCustomerHandler> _logger;
    readonly IRepository<Customer> _repository;

    public UpdateCustomerHandler(ILogger<UpdateCustomerHandler> logger, IRepository<Customer> repository)
    {
        _logger = logger;
        _repository = repository;
    }
    
    public async Task<UpdateCustomerResponse> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetAsync(command.Id);
        if (customer == null)
            throw new DomainException($"Customer with id {command.Id} does not exist");
        
        customer.WithName(command.FullName);
        
        await _repository.StoreAsync(customer);
        
        _logger.LogInformation($"Updating customer with ID: {command.Id}");
        
        var response = new UpdateCustomerResponse(customer.Id, customer.FullName, customer.BirthDate, customer.DocumentTax);
        
        return response;
    }
}