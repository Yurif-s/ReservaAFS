using ReservaAFS.Communication.Responses;

namespace ReservaAFS.Application.UseCases.Equipments.GetAll;
public interface IGetAllEquipmentsUseCase
{
    public Task<ResponseEquipmentsJson> Execute();
}
