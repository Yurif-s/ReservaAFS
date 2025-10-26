using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReservaAFS.Infrastructure.DataAccess;

namespace ReservaAFS.Infrastructure.Migrations;
public static class DatabaseMigration
{
    public async static Task MigrateDatabase(IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<ReservaAFSDbContext>();

        await dbContext.Database.MigrateAsync();
    }
}
