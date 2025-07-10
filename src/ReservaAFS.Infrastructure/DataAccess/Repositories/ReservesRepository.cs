using Microsoft.EntityFrameworkCore;
using ReservaAFS.Domain.Entities;
using ReservaAFS.Domain.Repositories.Reserves;

namespace ReservaAFS.Infrastructure.DataAccess.Repositories;
internal class ReservesRepository : IReservesRepository
{
    private ReservaAFSDbContext _dbContext;
    public ReservesRepository(ReservaAFSDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Add(Reserve reserve) => await _dbContext.Reserves.AddAsync(reserve);

    public async Task<List<Reserve>> GetAll()
    {
        return await _dbContext.Reserves.ToListAsync();
    }
}
