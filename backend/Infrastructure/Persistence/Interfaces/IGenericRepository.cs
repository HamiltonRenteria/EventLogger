using Domain.Entities;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<bool> RegisterAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null);
    }
}
