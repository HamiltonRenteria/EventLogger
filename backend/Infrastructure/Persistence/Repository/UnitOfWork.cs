using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Interfaces;

namespace Infrastructure.Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EventLoggerContext _databaseContext;
        public IUserRepository User { get; private set; }
        public IEventRepository Event { get; private set; }

        public UnitOfWork(EventLoggerContext databaseContext)
        {
            _databaseContext = databaseContext;
            User = new UserRepository(_databaseContext);
            Event = new EventRepository(_databaseContext);
        }

        public void Dispose()
        {
            _databaseContext.Dispose();
        }

        public void SaveChanges()
        {
            _ = _databaseContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            _ = await _databaseContext.SaveChangesAsync();
        }
    }
}
