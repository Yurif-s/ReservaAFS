using ReservaAFS.Communication.Responses;

namespace ReservaAFS.Application.UseCases.Users.GetAll;
public interface IGetAllUsersUseCase
{
    public Task<ResponseUsersJson> Execute();
}
