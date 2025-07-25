﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReservaAFS.Domain.Repositories;
using ReservaAFS.Domain.Repositories.Reserves;
using ReservaAFS.Infrastructure.DataAccess;
using ReservaAFS.Infrastructure.DataAccess.Repositories;

namespace ReservaAFS.Infrastructure;
public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);
        AddDbContext(services, configuration);
    }
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IReservesReadOnlyRepository, ReservesRepository>();
        services.AddScoped<IReservesWriteOnlyRepository, ReservesRepository>();
        services.AddScoped<IReserveUpdateOnlyRepository, ReservesRepository>();
    }
    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");

        var serverVersion = new MySqlServerVersion(new Version(8, 0, 42));

        services.AddDbContext<ReservaAFSDbContext>(config => config.UseMySql(connectionString, serverVersion));
    }
}
