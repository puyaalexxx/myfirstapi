﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFirstApi.Models;

namespace MyFirstApi.Data;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("Contacts");
        builder.HasKey(i => i.Id);
        builder.Property(p => p.Id).HasColumnName(nameof(Contact.Id));
        builder.Property(p => p.FirstName).HasColumnName(nameof(Contact.FirstName)).HasColumnType("varchar(64)").IsRequired();
        builder.Property(p => p.LastName).HasColumnName(nameof(Contact.LastName)).HasColumnType("varchar(64)").IsRequired();
        builder.Property(p => p.Email).HasColumnName(nameof(Contact.Email)).HasColumnType("varchar(128)").IsRequired();
        builder.HasIndex(p => p.Email).IsUnique();
        builder.Property(p => p.Phone).HasColumnName(nameof(Contact.Phone)).HasColumnType("varchar(32)");
        builder.Property(p => p.Company).HasColumnName(nameof(Contact.Company)).HasColumnType("varchar(128)");
       // builder.Property(p => p.Address).HasColumnName(nameof(Contact.Address)).HasColumnType("varchar(128)");
        builder.Property(p => p.City).HasColumnName(nameof(Contact.City)).HasColumnType("varchar(64)");
        builder.Property(p => p.State).HasColumnName(nameof(Contact.State)).HasColumnType("varchar(64)");
        builder.Property(p => p.Zip).HasColumnName(nameof(Contact.Zip)).HasColumnType("varchar(16)");
        builder.Property(p => p.Country).HasColumnName(nameof(Contact.Country)).HasColumnType("varchar(64)");
        builder.Property(p => p.Notes).HasColumnName(nameof(Contact.Notes)).HasColumnType("varchar(256)");

        // Use owned entity type
        // builder.OwnsOne(c => c.Address, a =>
        // {
        //     a.WithOwner(x => x.Contact);
        //     a.Property(a => a.Street).HasColumnName("Street").HasMaxLength(64).IsRequired();
        //     a.Property(a => a.City).HasColumnName("City").HasMaxLength(32).IsRequired();
        //     a.Property(a => a.State).HasColumnName("State").HasMaxLength(32).IsRequired();
        //     a.Property(a => a.ZipCode).HasColumnName("ZipCode").HasMaxLength(16).IsRequired();
        // });
    }
}