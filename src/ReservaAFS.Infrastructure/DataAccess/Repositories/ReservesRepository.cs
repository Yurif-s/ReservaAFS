using Microsoft.EntityFrameworkCore;
using ReservaAFS.Domain.Entities;
using ReservaAFS.Domain.Repositories.Reserves;

namespace ReservaAFS.Infrastructure.DataAccess.Repositories;
internal class ReservesRepository : IReservesReadOnlyRepository, IReservesWriteOnlyRepository, IReserveUpdateOnlyRepository
{
    private readonly ReservaAFSDbContext _dbContext;
    public ReservesRepository(ReservaAFSDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Add(Reserve reserve) => await _dbContext.Reserves.AddAsync(reserve);

    public async Task<bool> Delete(long id)
    {
        var result = await _dbContext.Reserves.FirstOrDefaultAsync(reserve => reserve.Id == id);
        if (result is null) 
            return false;

        _dbContext.Reserves.Remove(result);

        return true;
    }

    public async Task<List<Reserve>> GetAll() => await _dbContext.Reserves.AsNoTracking().ToListAsync();

    async Task<Reserve?> IReserveUpdateOnlyRepository.GetById(long id) => await _dbContext.Reserves.FirstOrDefaultAsync(reserve => reserve.Id == id);
    async Task<Reserve?> IReservesReadOnlyRepository.GetById(long id) => await _dbContext.Reserves.AsNoTracking().FirstOrDefaultAsync(reserve => reserve.Id == id);

    public void Update(Reserve reserve) => _dbContext.Reserves.Update(reserve);

    public async Task<bool> IsAvailable(long id, DateTime reservationTime, int classNumber, long reserveIdToIgnore = 0)
    {
        var conflicting = await _dbContext.Reserves
            .AnyAsync(reserve => reserve.EquipmentId == id &&
                        reserve.ReservationTime.Date == reservationTime.Date &&
                        reserve.Class == classNumber &&
                        reserve.Id != reserveIdToIgnore);

        return !conflicting;
    }
}
