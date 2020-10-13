using Database.Model.Shared;
using Microsoft.EntityFrameworkCore;
using System;

namespace Database.Logic.Context
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
