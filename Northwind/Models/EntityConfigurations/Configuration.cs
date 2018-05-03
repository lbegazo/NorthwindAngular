using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models.EntityConfigurations
{
    public class ProductFeatureConfiguration : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> entity)
        {            
            entity.HasKey(e => new { e.ProductId, e.FeatureId });

            entity.HasOne(e => e.Product)
                .WithMany(p => p.Features)
                .HasForeignKey(e => e.ProductId);

            entity.HasOne(e => e.Feature)
                .WithMany(f => f.Products)
                .HasForeignKey(e => e.FeatureId);

        }
    }
}
