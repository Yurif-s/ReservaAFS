﻿using Microsoft.EntityFrameworkCore;
using ReservaAFS.Domain.Entities;
using ReservaAFS.Domain.Repositories.Reserves;

namespace ReservaAFS.Infrastructure.DataAccess.Repositories;
internal class ReservesRepository : IReservesReadOnlyRepository, IReservesWriteOnlyRepository, IReserveUpdateOnlyRepository
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

    public async Task<List<Reserve>> GetAll() => await _dbContext.Reserves.AsNoTracking().ToListAsync();

    async Task<Reserve?> IReserveUpdateOnlyRepository.GetById(long id) => await _dbContext.Reserves.FirstOrDefaultAsync(expense => expense.Id == id);
    async Task<Reserve?> IReservesReadOnlyRepository.GetById(long id) => await _dbContext.Reserves.AsNoTracking().FirstOrDefaultAsync(expense => expense.Id == id);

    public void Update(Reserve reserve) => _dbContext.Reserves.Update(reserve);
}
