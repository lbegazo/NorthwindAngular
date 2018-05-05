using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models.EntityConfigurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> entity)
        {
            #region Suppliers

            entity.HasKey(e => e.Id);

            entity.HasIndex(e => e.Name)
                .HasName("Name");

            entity.HasIndex(e => e.PostalCode)
                .HasName("PostalCode");

            entity.Property(e => e.Id)
                .HasColumnName("ID");
                //.ValueGeneratedOnAdd();

            entity.Property(e => e.Address)
                .HasMaxLength(60);

            entity.Property(e => e.City)
                .HasMaxLength(15);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(40);

            entity.Property(e => e.ContactName)
                .HasMaxLength(30);

            entity.Property(e => e.ContactTitle)
                .HasMaxLength(30);

            entity.Property(e => e.Country).HasMaxLength(15);

            entity.Property(e => e.Fax).HasMaxLength(24);

            entity.Property(e => e.HomePage).HasColumnType("ntext");

            entity.Property(e => e.Phone).HasMaxLength(24);

            entity.Property(e => e.PostalCode).HasMaxLength(10);

            entity.Property(e => e.Region).HasMaxLength(15);

            entity.Property(e => e.ContactEmail)
                .HasMaxLength(60);

            #endregion Suppliers
        }
    }
}
