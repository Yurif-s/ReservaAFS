using ReservaAFS.Communication.Requests;

namespace ReservaAFS.Application.UseCases.Users.ChangePassword;
public interface IChangePasswordUseCase
{
    Task Execute(RequestChangePasswordJson request);
}
