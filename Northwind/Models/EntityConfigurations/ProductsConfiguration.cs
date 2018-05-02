using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models.EntityConfigurations
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            #region Products

            entity.HasKey(p => p.ProductId);

            entity.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Category");

            entity.Property(p => p.CategoryId)
                .HasColumnName("CategoryID");

            entity.HasOne(p => p.Supplier)
                    .WithMany(s => s.Products)
                    .HasForeignKey(p => p.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Supplier");

            entity.Property(p => p.SupplierId)
            .HasColumnName("SupplierID");

            entity.Property(p => p.ProductId)
                .IsRequired()
                .HasColumnName("ProductID");

            entity.Property(p => p.ProductName)
                .IsRequired()
                .HasMaxLength(40);


            entity.Property(p => p.QuantityPerUnit)
                .HasMaxLength(20);

            entity.Property(p => p.UnitPrice)
                .HasColumnType("money");

            entity.Property(p => p.UnitsInStock)
                .HasColumnType("smallint");

            entity.Property(p => p.UnitsOnOrder)
                .HasColumnType("smallint");

            entity.Property(p => p.ReorderLevel)
                .HasColumnType("smallint");

            entity.Property(p => p.Discontinued)
                .IsRequired()
                .HasColumnType("bit");


            #endregion Products            
        }
    }
}
