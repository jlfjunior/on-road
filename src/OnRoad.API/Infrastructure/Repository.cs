using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OnRoad.API.Domain;

namespace OnRoad.API.Infrastructure;

public class Repository<T> : IRepository<T> where T : class, IEntity 
{
    readonly CustomerDbContext _dbContext;

    public Repository(CustomerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> GetAsync(Guid id)
    {
        var customer = await _dbContext.Set<T>().FindAsync(id);
        
        return customer;
    }

    public async Task StoreAsync(T entity)
    {
        var existingEntity = await _dbContext.Set<T>().FindAsync(entity.Id);
        
        if (entity.Id == Guid.Empty || existingEntity == null)
            _dbContext.Set<T>().Add(entity);
        else
            _dbContext.Entry(entity).State = EntityState.Modified;
        
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
    {
        var query = _dbContext.Set<T>();
        
        if (filter != null) 
            query.Where(filter);
        
        var customers = await query.ToListAsync();
        
        return customers;
    }
}