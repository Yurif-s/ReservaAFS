using ReservaAFS.Domain.Entities;

namespace ReservaAFS.Domain.Repositories.Reserves;
public interface IReservesWriteOnlyRepository
{
    Task Add(Reserve reserve);
    /// <summary>
    /// This function return TRUE if the deletion was successful
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> Delete(long id);
}
