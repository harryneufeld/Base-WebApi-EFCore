using Microsoft.EntityFrameworkCore;

namespace Backend.Database.Base
{
    public abstract class DatabaseContextBase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MssqlLocalDb;Initial Catalog=BaseEfDatabase;");
        }
    }
}
