namespace Infrastructure.Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        IEventRepository Event { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
