using ReservaAFS.Communication.Responses;

namespace ReservaAFS.Application.UseCases.Equipments.GetById;
public interface IGetByIdEquipmentUseCase
{
    public Task<ResponseEquipmentJson> Execute(long id);
}
