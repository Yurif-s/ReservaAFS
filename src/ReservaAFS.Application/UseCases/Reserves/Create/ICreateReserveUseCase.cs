using ReservaAFS.Communication.Requests;
using ReservaAFS.Communication.Responses;

namespace ReservaAFS.Application.UseCases.Reserves.Create;
public interface ICreateReserveUseCase
{
    public ResponseCreateReserveJson Execute(RequestCreateReserveJson request);
}
