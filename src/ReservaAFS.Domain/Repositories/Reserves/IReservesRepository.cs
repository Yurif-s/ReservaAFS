using ReservaAFS.Domain.Entities;

namespace ReservaAFS.Domain.Repositories.Reserves;
public interface IReservesRepository
{
    void Add(Reserve reserve);
}
