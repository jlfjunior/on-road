using MediatR;
using Microsoft.Extensions.Logging;
using OnRoad.Application.Models.Responses;
using OnRoad.Domain.Entities;
using OnRoad.Domain.Exceptions;
using OnRoad.SharedKernel;

namespace OnRoad.Application.Commands.CreateCustomer;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResponse>
{
    readonly ILogger<CreateCustomerHandler> _logger;
    readonly IRepository<Customer> _repository;
    
    public CreateCustomerHandler(ILogger<CreateCustomerHandler> logger, IRepository<Customer> repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public async Task<CreateCustomerResponse> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = new Customer(command.FullName, command.DocumentTax, command.BirthDate);
        
        var x = await _repository.GetAllAsync(x => x.DocumentTax == command.DocumentTax);
        
        if (x.Any())
            throw new DomainException($"Customer with tax {command.DocumentTax} already exists");
        
        await _repository.StoreAsync(customer);

        _logger.LogInformation($"Created Customer with ID: {customer.Id}");
        
        var response = new CreateCustomerResponse(customer.Id, customer.FullName, customer.BirthDate, customer.DocumentTax);

        return response;
    }
}