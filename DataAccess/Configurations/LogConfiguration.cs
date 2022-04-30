using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class LogConfiguration : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Id).UseIdentityColumn();
            builder.Property(x => x.MachineName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Logged).IsRequired();
            builder.Property(x => x.Level).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Logger).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Message).HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.Callsite).HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.Exception).HasColumnType("nvarchar(MAX)");

        }
    }
}
