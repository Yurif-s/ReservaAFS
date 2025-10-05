using ReservaAFS.Domain.Entities;

namespace ReservaAFS.Domain.Repositories.Equipments;
public interface IEquipmentsUpdateOnlyRepository
{
    Task<Equipment?> GetById(long id);
    void Update(Equipment equipment);
}
