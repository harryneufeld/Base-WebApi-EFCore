using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Model.Entity.MasterData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Database.EntityConfiguration.MasterData
{
    internal class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.CompanyId);
            builder.Property(x => x.Name);
            builder.Property(x => x.PhoneNumber);
            builder.Property(x => x.Mandator);
            builder.Property(x => x.Address);
            builder.Property(x => x.PersonList);
        }
    }
}
