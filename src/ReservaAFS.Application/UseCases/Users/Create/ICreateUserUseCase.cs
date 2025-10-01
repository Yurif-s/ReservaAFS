using ReservaAFS.Communication.Requests;
using ReservaAFS.Communication.Responses;

namespace ReservaAFS.Application.UseCases.Users.Create;
public interface ICreateUserUseCase
{
    public Task<ResponseCreatedUserJson> Execute(RequestUserJson request);
}
