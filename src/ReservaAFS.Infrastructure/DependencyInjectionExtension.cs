using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReservaAFS.Domain.Repositories;
using ReservaAFS.Domain.Repositories.Equipments;
using ReservaAFS.Domain.Repositories.Reserves;
using ReservaAFS.Domain.Repositories.Users;
using ReservaAFS.Domain.Security;
using ReservaAFS.Infrastructure.DataAccess;
using ReservaAFS.Infrastructure.DataAccess.Repositories;
using ReservaAFS.Infrastructure.Security.Cryptography;


namespace ReservaAFS.Infrastructure;
public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPasswordEncripter, Security.Cryptography.BCrypt>();

        AddRepositories(services);
        AddDbContext(services, configuration);
    }
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IEquipmentsReadOnlyRepository, EquipmentsRepository>();
        services.AddScoped<IEquipmentsWriteOnlyRepository, EquipmentsRepository>();
        services.AddScoped<IEquipmentsUpdateOnlyRepository, EquipmentsRepository>();
        services.AddScoped<IReservesReadOnlyRepository, ReservesRepository>();
        services.AddScoped<IReservesWriteOnlyRepository, ReservesRepository>();
        services.AddScoped<IReserveUpdateOnlyRepository, ReservesRepository>();
        services.AddScoped<IUsersReadOnlyRepository, UsersRepository>();
        services.AddScoped<IUsersUpdateOnlyRepository, UsersRepository>();
        services.AddScoped<IUsersWriteOnlyRepository, UsersRepository>();
    }
    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");

        var serverVersion = new MySqlServerVersion(new Version(8, 0, 42));

        services.AddDbContext<ReservaAFSDbContext>(config => config.UseMySql(connectionString, serverVersion));
    }
}
