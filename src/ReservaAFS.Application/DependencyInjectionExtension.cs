using Microsoft.Extensions.DependencyInjection;
using ReservaAFS.Application.AutoMapper;
using ReservaAFS.Application.UseCases.Equipments.Create;
using ReservaAFS.Application.UseCases.Equipments.GetAll;
using ReservaAFS.Application.UseCases.Equipments.GetById;
using ReservaAFS.Application.UseCases.Reserves.Create;
using ReservaAFS.Application.UseCases.Reserves.Delete;
using ReservaAFS.Application.UseCases.Reserves.GetAll;
using ReservaAFS.Application.UseCases.Reserves.GetById;
using ReservaAFS.Application.UseCases.Reserves.Update;
using ReservaAFS.Application.UseCases.Users.Create;

namespace ReservaAFS.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddUseCases(services);
        AddAutoMapper(services);    
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }
    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<ICreateEquipmentUseCase, CreateEquipmentUseCase>();
        services.AddScoped<IGetAllEquipmentsUseCase, GetAllEquipmentsUseCase>();
        services.AddScoped<IGetByIdEquipmentUseCase, GetByIdEquipmentUseCase>();
        services.AddScoped<ICreateReserveUseCase, CreateReserveUseCase>();
        services.AddScoped<IGetAllReservesUseCase, GetAllReservesUseCase>();
        services.AddScoped<IGetReserveByIdUseCase, GetReserveByIdUseCase>();
        services.AddScoped<IDeleteReserveUseCase, DeleteReserveUseCase>();
        services.AddScoped<IUpdateReserveUseCase, UpdateReserveUseCase>();
        services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
    }
}
