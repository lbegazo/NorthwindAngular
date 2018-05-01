using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models.EntityConfigurations
{
    public class CustomerDemographicsConfiguration : IEntityTypeConfiguration<CustomerDemographics>
    {
        public void Configure(EntityTypeBuilder<CustomerDemographics> entity)
        {
            #region CustomerDemographics

            entity.HasKey(cd => cd.CustomerTypeId);

            entity.Property(cd => cd.CustomerTypeId)
                .HasColumnType("nchar(10)")
                .HasColumnName("CustomerTypeID");
            entity.Property(cd => cd.CustomerDesc).HasColumnType("ntext");

            #endregion CustomerDemographics
        }
    }
}
