using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Id).UseIdentityColumn();
            builder.Property(x => x.Status).HasDefaultValue(true);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Surname).IsRequired();
            builder.Property(x => x.TelephoneNr).IsRequired().HasMaxLength(14);
            builder.Property(x => x.Create_by).HasMaxLength(100);
            builder.Property(x => x.Update_by).HasMaxLength(100);
        }
    }
}
