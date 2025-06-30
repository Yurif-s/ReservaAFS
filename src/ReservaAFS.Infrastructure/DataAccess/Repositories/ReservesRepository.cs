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
    public void Add(Reserve reserve) => _dbContext.Reserves.Add(reserve);
}
