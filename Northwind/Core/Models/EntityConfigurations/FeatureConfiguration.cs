using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models.EntityConfigurations
{
    public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> entity)
        {
            #region Feature

            entity.HasKey(f => f.Id);

            entity.Property(f => f.Id)
                .HasColumnName("ID");

            entity.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(f => f.Description)
                .HasMaxLength(255);

            #endregion Feature
        }
    }
}
