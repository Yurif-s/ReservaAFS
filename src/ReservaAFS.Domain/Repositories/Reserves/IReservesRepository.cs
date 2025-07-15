using ReservaAFS.Domain.Entities;

namespace ReservaAFS.Domain.Repositories.Reserves;
public interface IReservesRepository
{
    Task Add(Reserve reserve);
    Task<List<Reserve>> GetAll();
    Task<Reserve?> GetById(long id);
}
