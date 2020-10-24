using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Model.Entity.MasterData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Database.EntityConfiguration.MasterData
{
    internal class BusinessItemConfiguration : IEntityTypeConfiguration<BusinessItem>
    {
        public void Configure(EntityTypeBuilder<BusinessItem> builder)
        {
            builder.HasKey(x => x.BusinessItemId);
            builder.Property(x => x.Name);
            builder.Property(x => x.PhoneNumber);
            builder.Property(x => x.Mandator);
            builder.Property(x => x.Address);
            builder.Property(x => x.PersonList);
        }
    }
}
