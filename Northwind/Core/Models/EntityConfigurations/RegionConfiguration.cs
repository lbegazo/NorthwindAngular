using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models.EntityConfigurations
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> entity)
        {
            #region Region


            entity.HasKey(r => r.RegionId);

            entity.Property(r => r.RegionId)
                .HasColumnName("RegionID")
                .ValueGeneratedNever();

            entity.Property(r => r.RegionDescription)
                .IsRequired()
                .HasColumnType("nchar(50)");


            #endregion Region
        }
    }
}
