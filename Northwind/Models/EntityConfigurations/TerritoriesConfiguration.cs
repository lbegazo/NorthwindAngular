using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models.EntityConfigurations
{
    public class TerritoriesConfiguration : IEntityTypeConfiguration<Territorie>
    {
        public void Configure(EntityTypeBuilder<Territorie> entity)
        {
            #region Territories

           
                entity.HasKey(t => t.TerritoryId)
                    .ForSqlServerIsClustered(false);

                entity.Property(t => t.TerritoryId)
                    .HasColumnName("TerritoryID")
                    .HasMaxLength(20)
                    .ValueGeneratedNever();

                entity.Property(t => t.RegionId).HasColumnName("RegionID");

                entity.Property(t => t.TerritoryDescription)
                    .IsRequired()
                    .HasColumnType("nchar(50)");

                entity.HasOne(t => t.Region)
                        .WithMany(p => p.Territories)
                        .HasForeignKey(t => t.RegionId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Territories_Region");

      

            #endregion Territories
        }
    }
}
