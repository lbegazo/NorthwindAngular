using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models.EntityConfigurations
{
    public class CategoriesConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            #region Categories

            entity.HasKey(c => c.Id);

            entity.Property(e=>e.Id)
                .HasColumnName("ID");

            entity.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(15);

            entity.Property(c => c.Description).HasColumnType("nText");

            entity.Property(c => c.Picture).HasColumnType("image");


            #endregion Categories
        }
    }
}
