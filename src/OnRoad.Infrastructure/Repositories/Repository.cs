using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OnRoad.Infrastructure;
using OnRoad.Infrastructure.Repositories;
using OnRoad.SharedKernel;

namespace OnRoad.API.Infrastructure;

public class Repository<T> : IRepository<T> where T : class, IEntity 
{
    protected readonly CustomerDbContext DbContext;

    public Repository(CustomerDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<T> GetAsync(Guid id)
    {
        var customer = await DbContext.Set<T>().FindAsync(id);
        
        return customer;
    }

    public async Task StoreAsync(T entity)
    {
        var existingEntity = await DbContext.Set<T>().FindAsync(entity.Id);
        
        if (entity.Id == Guid.Empty || existingEntity == null)
            DbContext.Set<T>().Add(entity);
        else
            DbContext.Entry(entity).State = EntityState.Modified;
        
        await DbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
    {
        var query = DbContext.Set<T>();
        
        if (filter != null) 
            query.Where(filter);
        
        var customers = await query.ToListAsync();
        
        return customers;
    }

    public async Task DeleteAsync(T entity)
    {
        DbContext.Set<T>().Remove(entity);
        
        await DbContext.SaveChangesAsync();
    }
}