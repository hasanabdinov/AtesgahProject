using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Id).UseIdentityColumn();
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.DueDate).IsRequired();
            builder.Property(x => x.InvoiceNr).IsRequired();
            builder.Property(x => x.OrderNr).IsRequired();
            builder.Property(x => x.Create_by).HasMaxLength(100);
            builder.Property(x => x.Status).HasDefaultValue(true);
            builder.Property(x => x.Update_by).HasMaxLength(100);
            builder.HasOne(x => x.Loan).WithMany(z => z.Invoices).HasForeignKey(z => z.LoanId);
        }
    }
}
