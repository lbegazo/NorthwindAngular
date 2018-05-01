using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models.EntityConfigurations
{
    public class CustomersConfiguration : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> entity)
        {
            #region Customer

            entity.HasKey(c => c.CustomerId);

            entity.Property(c => c.CustomerId).HasColumnType("nchar(5)");

            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(40);

            entity.Property(e => e.ContactName).HasMaxLength(100);

            entity.Property(e => e.ContactTitle).HasMaxLength(30);

            entity.Property(e => e.Address).HasMaxLength(60);

            entity.Property(e => e.City).HasMaxLength(15);

            entity.Property(e => e.Region).HasMaxLength(15);

            entity.Property(e => e.PostalCode).HasMaxLength(10);

            entity.Property(e => e.Country).HasMaxLength(15);

            entity.Property(e => e.Phone).HasMaxLength(24);

            entity.Property(e => e.Fax).HasMaxLength(24);

            #endregion Customer
        }
    }
}
