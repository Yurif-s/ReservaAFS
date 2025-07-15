using ReservaAFS.Communication.Responses;

namespace ReservaAFS.Application.UseCases.Reserves.GetById;
public interface IGetReserveByIdUseCase
{
    public Task<ResponseReserveJson> Execute(long id);
}
