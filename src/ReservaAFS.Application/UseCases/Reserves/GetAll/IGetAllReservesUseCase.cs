using ReservaAFS.Communication.Responses;

namespace ReservaAFS.Application.UseCases.Reserves.GetAll;
public interface IGetAllReservesUseCase
{
    public Task<ResponseReservesJson> Execute();
}
