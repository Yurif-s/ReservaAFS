using ReservaAFS.Communication.Responses;

namespace ReservaAFS.Application.UseCases.Users.GetById;
public interface IGetByIdUserUseCase
{
    public Task<ResponseUserJson> Execute(long id);
}
