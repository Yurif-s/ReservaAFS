using Microsoft.EntityFrameworkCore;
using ReservaAFS.Domain.Entities;
using ReservaAFS.Domain.Repositories.Users;

namespace ReservaAFS.Infrastructure.DataAccess.Repositories;
internal class UsersRepository : IUsersReadOnlyRepository, IUsersUpdateOnlyRepository, IUsersWriteOnlyRepository
{
    private readonly ReservaAFSDbContext _dbContext;
    public UsersRepository(ReservaAFSDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Add(User user) => await _dbContext.Users.AddAsync(user);

    public async Task<bool> Delete(long id)
    {
        var result = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);

        if (result is null)
            return false;

        _dbContext.Users.Remove(result);

        return true;
    }

    public async Task<List<User>> GetAll() => await _dbContext.Users.AsNoTracking().ToListAsync();

    async Task<User?> IUsersReadOnlyRepository.GetById(long id) =>
        await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Id == id);
    async Task<User?> IUsersUpdateOnlyRepository.GetById(long id) =>
        await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);

    public void Update(User user) => _dbContext.Users.Update(user);
}
