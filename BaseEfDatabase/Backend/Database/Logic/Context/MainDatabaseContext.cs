using Backend.Database.Logic.Base;
using Backend.Database.Model.Shared.MasterData;
using Backend.Database.Model.Shared.UserManagement;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database.Logic.Context
{
    public class MainDatabaseContext : BaseDatabaseContext
    {
        public DbSet<Mandator> Mandators { get; set; }
        public DbSet<BusinessItem> BusinessItems { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRight> UserRights { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserGroupRight> UserGroupRights { get; set; }

        public MainDatabaseContext()
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////Addresse hatte City als FK
            //modelBuilder.Entity<Address>()
            //    .HasOne(a => a.City)
            //    .WithMany(c => c.AddressList)
            //    .HasForeignKey(a => a.PostalCode)
            //    .HasPrincipalKey(c => c.PostalCode);
            //modelBuilder.Entity<City>()
            //    .HasKey(c => c.PostalCode);

            base.OnModelCreating(modelBuilder);
        }
    }
}
