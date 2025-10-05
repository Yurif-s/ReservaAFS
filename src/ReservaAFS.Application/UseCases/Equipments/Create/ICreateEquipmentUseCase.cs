using ReservaAFS.Communication.Requests;
using ReservaAFS.Communication.Responses;

namespace ReservaAFS.Application.UseCases.Equipments.Create;
public interface ICreateEquipmentUseCase
{
    public Task<ResponseCreatedEquipmentJson> Execute(RequestEquipmentJson request);
}
