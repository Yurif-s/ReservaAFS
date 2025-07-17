namespace ReservaAFS.Application.UseCases.Reserves.Delete;
public interface IDeleteReserveUseCase
{
    public Task Execute(long id);
}
