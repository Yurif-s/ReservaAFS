using ReservaAFS.Domain.Entities;

namespace ReservaAFS.Domain.Repositories.Equipments;
public interface IEquipmentsReadOnlyRepository
{
    Task<List<Equipment>> GetAll();
    Task<Equipment?> GetById(long id);
}
