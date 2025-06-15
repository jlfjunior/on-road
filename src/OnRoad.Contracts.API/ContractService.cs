using MongoDB.Driver;
using OnRoad.Contracts.API.Domain;

namespace OnRoad.Contracts.API;

public class ContractService : IContractService
{
    private readonly IMongoCollection<Contract> _collection;

    public ContractService(IMongoDatabase database)
    {
        _collection = database.GetCollection<Contract>("contracts");
    }
    
    public async Task<IEnumerable<Contract>> AllAsync()
    {
        var contracts = await _collection.Find(contract => true).ToListAsync();
        
        return contracts;
    }

    public Task<Contract> AddAsync(Guid customerId, Guid vehicleId, DateOnly startDate)
    {
        throw new NotImplementedException();
    }
}