using Microsoft.Extensions.DependencyInjection;
using ReservaAFS.Application.UseCases.Reserves.Create;

namespace ReservaAFS.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICreateReserveUseCase, CreateReserveUseCase>();
    }
}
