using Database.Logic.Context;
using Database.Model.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Logic
{
    public class MainDatabaseContext : BaseDatabaseContext
    {
        public DbSet<Mandator> Mandators { get; set; }
        public DbSet<BusinessItem> BusinessItems { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRight> UserRights { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<GroupRight> GroupRights { get; set; }

        public MainDatabaseContext()
        {
            Database.Migrate();
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

            base.OnModelCreating(modelBuilder);
        }
    }
}
