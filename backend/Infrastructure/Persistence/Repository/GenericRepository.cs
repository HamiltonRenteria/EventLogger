using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Helpers;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly EventLoggerContext _databaseContext;
        private readonly DbSet<T> _entity;

        public GenericRepository(EventLoggerContext databaseContext)
        {
            _databaseContext = databaseContext;
            _entity = _databaseContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            List<T> getAll = await _entity
                .AsNoTracking()
                .ToListAsync();

            return getAll;
        }

        public async Task<bool> RegisterAsync(T entity)
        {
            _ = await _databaseContext.AddAsync(entity);

            int recordAffected = await _databaseContext.SaveChangesAsync();
            return recordAffected > 0;
        }

        public IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _entity;

            if (filter is not null)
            {
                query = query.Where(filter);
            }

            return query;
        }

        public IQueryable<TDTO> Ordering<TDTO>(BasePaginationRequest request, IQueryable<TDTO> queryable, bool pagination = false) where TDTO : class
        {
            IQueryable<TDTO> queryDto = queryable;

            // Verifica si Sort tiene un valor antes de intentar ordenar
            if (!string.IsNullOrEmpty(request.Sort))
            {
                // Ordena dinámicamente en función del valor de "Order" en el request
                queryDto = request.Order == "desc"
                    ? queryable.OrderBy($"{request.Sort} desc")
                    : queryable.OrderBy(request.Sort); // sin "asc"
            }

            // Aplica la paginación si está habilitada
            if (pagination)
            {
                queryDto = queryDto.Paginate(request);
            }

            return queryDto;
        }
    }
}