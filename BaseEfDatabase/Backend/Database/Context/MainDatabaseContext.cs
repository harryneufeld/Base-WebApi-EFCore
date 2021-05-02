using Backend.Database.Base;
using Shared.Model.Entity.MasterData;
using Shared.Model.Entity.UserData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Backend.Database.EntityConfiguration.MasterData;

namespace Backend.Database.Context
{
    public class MainDatabaseContext : DatabaseContextBase
    {
        #region Fields
        private readonly ILoggerFactory loggerFactory;
        #endregion

        #region Properties
        public DbSet<Mandator> Mandators { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRight> UserRights { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserGroupRight> UserGroupRights { get; set; }
        #endregion

        #region Contructor
        public MainDatabaseContext(ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
            Database.Migrate();
        }
        #endregion

        #region Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                  .UseLoggerFactory(this.loggerFactory);

            base.OnConfiguring(optionsBuilder);
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

            //// Apply EntityConfigurations
            //modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        }
        #endregion
    }
}
