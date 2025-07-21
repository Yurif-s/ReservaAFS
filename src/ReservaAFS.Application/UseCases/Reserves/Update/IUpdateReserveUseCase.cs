using ReservaAFS.Communication.Requests;

namespace ReservaAFS.Application.UseCases.Reserves.Update;
public interface IUpdateReserveUseCase
{
    public Task Execute(long id, RequestReserveJson request);
}
