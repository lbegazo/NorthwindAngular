using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Northwind.Models.EntityConfigurations;

namespace Northwind.Models
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        { }

        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        
        public virtual DbSet<Shippers> Shippers { get; set; }        

        public virtual DbSet<Region> Region { get; set; }

        public virtual DbSet<Territories> Territories { get; set; }

        public virtual DbSet<Products> Products { get; set; }

        public virtual DbSet<CustomerDemographics> CustomerDemographics { get; set; }

        public virtual DbSet<Customers> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriesConfiguration());

            modelBuilder.ApplyConfiguration(new SuppliersConfiguration());

            modelBuilder.ApplyConfiguration(new ShippersConfiguration());

            modelBuilder.ApplyConfiguration(new RegionConfiguration());

            

            

            modelBuilder.ApplyConfiguration(new CustomerDemographicsConfiguration());

            modelBuilder.ApplyConfiguration(new CustomersConfiguration());

            modelBuilder.ApplyConfiguration(new CustomerCustomerDemoConfiguration());


        }
    }
}
