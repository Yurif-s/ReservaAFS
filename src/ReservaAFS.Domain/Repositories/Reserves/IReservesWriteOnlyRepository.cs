using ReservaAFS.Domain.Entities;

namespace ReservaAFS.Domain.Repositories.Reserves;
public interface IReservesWriteOnlyRepository
{
    Task Add(Reserve reserve);
}
