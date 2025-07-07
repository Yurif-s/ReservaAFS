namespace ReservaAFS.Domain.Repositories;
public interface IUnitOfWork
{
    Task Commit();
}
