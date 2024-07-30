using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFirstApi.Models;

namespace MyFirstApi.Data;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable("Invoices");
        builder.HasKey(i => i.Id);
        builder.Property(p => p.Id).HasColumnName(nameof(Invoice.Id));
        builder.Property(p => p.InvoiceNumber).HasColumnName(nameof(Invoice.InvoiceNumber)).HasColumnType("varchar(32)").IsRequired();
        builder.HasIndex(p => p.InvoiceNumber).IsUnique();
        builder.Property(p => p.ContactId).HasColumnName(nameof(Invoice.ContactId)).IsRequired();
        builder.Property(p => p.Description).HasColumnName(nameof(Invoice.Description)).HasMaxLength(256);
        builder.Property(p => p.Amount).HasColumnName(nameof(Invoice.Amount)).HasPrecision(18, 2);
        builder.Property(p => p.InvoiceDate).HasColumnName(nameof(Invoice.InvoiceDate)).HasColumnType("datetimeoffset").IsRequired();
        builder.Property(p => p.DueDate).HasColumnName(nameof(Invoice.DueDate)).HasColumnType("datetimeoffset").IsRequired();
        builder.Property(p => p.Status).HasColumnName(nameof(Invoice.Status)).HasMaxLength(16).HasConversion(
            v => v.ToString(),
            v => (InvoiceStatus)Enum.Parse(typeof(InvoiceStatus), v));
        //added on the InvoiceItem config class
        /*builder.HasMany(x => x.InvoiceItems)
            .WithOne(x => x.Invoice)
            .HasForeignKey(x => x.InvoiceId);*/
    }
}