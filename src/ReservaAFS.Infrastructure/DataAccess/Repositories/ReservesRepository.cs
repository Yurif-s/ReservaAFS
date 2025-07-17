using Microsoft.EntityFrameworkCore;
using ReservaAFS.Domain.Entities;
using ReservaAFS.Domain.Repositories.Reserves;

namespace ReservaAFS.Infrastructure.DataAccess.Repositories;
internal class ReservesRepository : IReservesReadOnlyRepository, IReservesWriteOnlyRepository
{
    private ReservaAFSDbContext _dbContext;
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

    public async Task<List<Reserve>> GetAll()
    {
        return await _dbContext.Reserves.AsNoTracking().ToListAsync();
    }

    public async Task<Reserve?> GetById(long id) => await _dbContext.Reserves.AsNoTracking().FirstOrDefaultAsync(expense => expense.Id == id);
    
}
