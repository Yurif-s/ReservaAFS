using ReservaAFS.Communication.Requests;

namespace ReservaAFS.Application.UseCases.Users.Update;
public interface IUpdateUserUseCase
{
    public Task Execute(long id, RequestUserJson request);
}
