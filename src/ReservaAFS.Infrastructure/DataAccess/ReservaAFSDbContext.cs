using Microsoft.EntityFrameworkCore;
using ReservaAFS.Domain.Entities;

namespace ReservaAFS.Infrastructure.DataAccess;
internal class ReservaAFSDbContext : DbContext
{
    public ReservaAFSDbContext(DbContextOptions options) : base(options)
    {
        
    }
    public DbSet<Reserve> Reserves { get; set; }
}
