using ReservaAFS.Communication.Requests;

namespace ReservaAFS.Application.UseCases.Equipments.Update;
public interface IUpdateEquipmentUseCase
{
    public Task Execute(long id, RequestEquipmentJson request);
}
