using Database.Model.Shared;
using Microsoft.EntityFrameworkCore;
using System;

namespace Database.Logic.Context
{
    public class BaseEfDatabaseContext : DbContext
    {
        public DbSet<Mandator> Mandators { get; set; }
        public DbSet<BusinessItem> BusinessItems { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MssqlLocalDb;Initial Catalog=BaseEfDatabase;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasOne(a => a.City)
                .WithMany(c => c.AddressList)
                .HasForeignKey(a => a.PostalCode)
                .HasPrincipalKey(c => c.PostalCode);

            modelBuilder.Entity<City>()
                .HasKey(c => c.PostalCode);
        }
    }
}
