using ReservaAFS.Domain.Repositories;

namespace ReservaAFS.Infrastructure.DataAccess;
internal class UnitOfWork : IUnitOfWork
{
    private readonly ReservaAFSDbContext _dbContext;
    public UnitOfWork(ReservaAFSDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Commit() => _dbContext.SaveChanges(); 
}
