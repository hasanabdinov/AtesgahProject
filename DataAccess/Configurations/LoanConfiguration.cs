using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Id).UseIdentityColumn();
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.LoanPeriod).IsRequired();
            builder.Property(x => x.PayoutDate).IsRequired();
            builder.Property(x => x.Create_by).HasMaxLength(100);
            builder.Property(x => x.Status).HasDefaultValue(true);
            builder.Property(x => x.Update_by).HasMaxLength(100);
            builder.HasOne(x => x.Client).WithMany(z => z.Loans).HasForeignKey(z => z.ClientId);

        }
    }
}
