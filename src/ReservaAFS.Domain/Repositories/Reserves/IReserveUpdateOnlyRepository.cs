using ReservaAFS.Domain.Entities;

namespace ReservaAFS.Domain.Repositories.Reserves;
public interface IReserveUpdateOnlyRepository
{
    Task<Reserve?> GetById(long id);
    void Update(Reserve reserve);
}
