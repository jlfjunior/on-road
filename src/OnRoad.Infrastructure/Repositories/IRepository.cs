using System.Linq.Expressions;
using OnRoad.SharedKernel;

namespace OnRoad.Infrastructure.Repositories;

public interface IRepository<T> where T : IEntity 
{
    Task<T> GetAsync(Guid id);
    Task StoreAsync(T entity);
    Task DeleteAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
}