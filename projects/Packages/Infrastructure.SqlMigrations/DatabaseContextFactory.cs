using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.SqlMigrations;

// ReSharper disable once UnusedType.Global
public class DatabaseContextFactory: IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
        optionsBuilder.UseSqlServer(
            @"Data Source=(localdb)\\MsSqlLocalDb;initial catalog=ProductsDbDev;Integrated Security=True; MultipleActiveResultSets=True",
            c => c.MigrationsAssembly(typeof(DatabaseContextFactory).Assembly)
        );

        return new DatabaseContext(optionsBuilder.Options);
    }
}