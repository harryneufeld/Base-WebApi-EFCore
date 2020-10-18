using Microsoft.EntityFrameworkCore;

namespace Backend.Database.Logic.Base
{
    public abstract class BaseDatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MssqlLocalDb;Initial Catalog=BaseEfDatabase;");
        }
    }
}
