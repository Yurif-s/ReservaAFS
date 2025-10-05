using Microsoft.EntityFrameworkCore;
using ReservaAFS.Domain.Entities;
using ReservaAFS.Domain.Repositories.Equipments;

namespace ReservaAFS.Infrastructure.DataAccess.Repositories;
internal class EquipmentsRepository : IEquipmentsReadOnlyRepository, IEquipmentsWriteOnlyRepository, IEquipmentsUpdateOnlyRepository
{
    private readonly ReservaAFSDbContext _dbContext;
    public EquipmentsRepository(ReservaAFSDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Add(Equipment equipment) => await _dbContext.Equipments.AddAsync(equipment);

    public async Task<bool> Delete(long id)
    {
        var result = await _dbContext.Equipments.FirstOrDefaultAsync(equipment => equipment.Id == id);

        if (result is null)
            return false;

        _dbContext.Equipments.Remove(result);

        return true;
    }

    public async Task<List<Equipment>> GetAll() => await _dbContext.Equipments.AsNoTracking().ToListAsync();

    async Task<Equipment?> IEquipmentsReadOnlyRepository.GetById(long id) =>
        await _dbContext.Equipments.FirstOrDefaultAsync(equipment => equipment.Id == id);
    async Task<Equipment?> IEquipmentsUpdateOnlyRepository.GetById(long id) =>
        await _dbContext.Equipments.AsNoTracking().FirstOrDefaultAsync(equipment => equipment.Id == id);

    public void Update(Equipment equipment) => _dbContext.Equipments.Update(equipment);
}
