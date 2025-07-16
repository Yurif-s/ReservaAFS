using ReservaAFS.Domain.Entities;

namespace ReservaAFS.Domain.Repositories.Reserves;
public interface IReservesReadOnlyRepository
{
    Task<List<Reserve>> GetAll();
    Task<Reserve?> GetById(long id);
}
