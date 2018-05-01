using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models.EntityConfigurations
{
    public class CustomerCustomerDemoConfiguration : IEntityTypeConfiguration<Territories>
    {
        public void Configure(EntityTypeBuilder<Territories> entity)
        {

            #region CustomerCustomerDemo


            entity.HasKey(cc => new { cc.CustomerId, cc.CustomerTypeId });

            entity.HasOne(cc => cc.Customer)
                .WithMany(c => c.CustomerCustomerDemos)
                .HasForeignKey(cc => cc.CustomerId);

            entity.HasOne(cc => cc.CustomerDemographic)
                .WithMany(cd => cd.CustomerCustomerDemos)
                .HasForeignKey(cc => cc.CustomerTypeId);



            #endregion CustomerCustomerDemo
        }
    }
}
