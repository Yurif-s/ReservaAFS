namespace ReservaAFS.Application.UseCases.Users.Delete;
public interface IDeleteUserUseCase
{
    public Task Execute(long id);
}
