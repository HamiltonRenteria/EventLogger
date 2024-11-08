using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Interfaces;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string? assembly = typeof(EventLoggerContext).Assembly.FullName;

            _ = services.AddDbContext<EventLoggerContext>(
                option => option.UseSqlServer(
                    configuration.GetConnectionString("PersistenceConnection"),
                    b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient);

            _ = services.AddTransient<IUnitOfWork, UnitOfWork>();
            _ = services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
