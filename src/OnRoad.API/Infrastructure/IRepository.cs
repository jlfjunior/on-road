using System.Linq.Expressions;
using OnRoad.API.Domain;

namespace OnRoad.API.Infrastructure;

public interface IRepository<T> where T : IEntity 
{
    Task<T> GetAsync(Guid id);
    Task StoreAsync(T entity);
    Task DeleteAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
}