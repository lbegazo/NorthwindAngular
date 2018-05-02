using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models.EntityConfigurations
{
    public class ShippersConfiguration : IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> entity)
        {
            #region Shippers


            entity.HasKey(e => e.ShipperId);

            entity.Property(e => e.ShipperId).HasColumnName("ShipperID");

            entity.Property("CompanyName")
                .HasMaxLength(40)
                .IsRequired();

            entity.Property("Phone")
                .HasMaxLength(24);



            #endregion Shippers
        }
    }
}
