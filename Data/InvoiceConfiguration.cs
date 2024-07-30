﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFirstApi.Models;

namespace MyFirstApi.Data;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable("Invoices");
        builder.HasKey(i => i.Id);
        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.InvoiceNumber).HasColumnName("InvoiceNumber").HasColumnType("varchar(32)").IsRequired();
        builder.Property(p => p.ContactName).HasColumnName("ContactName").HasMaxLength(32).IsRequired();
        builder.Property(p => p.Description).HasColumnName("Description").HasMaxLength(256);
        builder.Property(p => p.Amount).HasColumnName("Amount").HasPrecision(18, 2);
        builder.Property(p => p.InvoiceDate).HasColumnName("InvoiceDate").HasColumnType("datetimeoffset").IsRequired();
        builder.Property(p => p.DueDate).HasColumnName("DueDate").HasColumnType("datetimeoffset").IsRequired();
        builder.Property(p => p.Status).HasColumnName("Status").HasMaxLength(16).HasConversion(
            v => v.ToString(),
            v => (InvoiceStatus)Enum.Parse(typeof(InvoiceStatus), v));
        //added on the InvoiceItem config class
        /*builder.HasMany(x => x.InvoiceItems)
            .WithOne(x => x.Invoice)
            .HasForeignKey(x => x.InvoiceId);*/
    }
}