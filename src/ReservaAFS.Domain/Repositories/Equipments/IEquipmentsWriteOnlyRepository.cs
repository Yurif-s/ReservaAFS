using ReservaAFS.Domain.Entities;

namespace ReservaAFS.Domain.Repositories.Equipments;
public interface IEquipmentsWriteOnlyRepository
{
    Task Add(Equipment equipment);
    /// <summary>
    /// This function return TRUE if the deletion was successful
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> Delete(long id);
}
