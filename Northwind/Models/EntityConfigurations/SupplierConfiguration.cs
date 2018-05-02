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

            entity.HasKey(e => e.SupplierId);

            entity.HasIndex(e => e.CompanyName)
                .HasName("CompanyName");

            entity.HasIndex(e => e.PostalCode)
                .HasName("PostalCode");

            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            entity.Property(e => e.Address).HasMaxLength(60);

            entity.Property(e => e.City).HasMaxLength(15);

            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(40);

            entity.Property(e => e.ContactName).HasMaxLength(30);

            entity.Property(e => e.ContactTitle).HasMaxLength(30);

            entity.Property(e => e.Country).HasMaxLength(15);

            entity.Property(e => e.Fax).HasMaxLength(24);

            entity.Property(e => e.HomePage).HasColumnType("ntext");

            entity.Property(e => e.Phone).HasMaxLength(24);

            entity.Property(e => e.PostalCode).HasMaxLength(10);

            entity.Property(e => e.Region).HasMaxLength(15);

            #endregion Suppliers
        }
    }
}
