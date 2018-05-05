using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Northwind.Models;
using Northwind.Models.EntityConfigurations;

namespace Northwind.Persistence
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        { }

        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        
        public virtual DbSet<Shipper> Shippers { get; set; }        

        public virtual DbSet<Region> Region { get; set; }

        public virtual DbSet<Territory> Territories { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<CustomerDemographics> CustomerDemographics { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<CustomerCustomerDemo> CustomerCustomerDemos { get; set; }

        public virtual DbSet<Feature> Features { get; set; }

        public virtual DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriesConfiguration());

            modelBuilder.ApplyConfiguration(new SupplierConfiguration());

            modelBuilder.ApplyConfiguration(new ShippersConfiguration());

            modelBuilder.ApplyConfiguration(new RegionConfiguration());

            modelBuilder.ApplyConfiguration(new TerritoryConfiguration());

            modelBuilder.ApplyConfiguration(new ProductsConfiguration());

            modelBuilder.ApplyConfiguration(new CustomerDemographicsConfiguration());

            modelBuilder.ApplyConfiguration(new CustomersConfiguration());

            modelBuilder.ApplyConfiguration(new CustomerCustomerDemoConfiguration());

            modelBuilder.ApplyConfiguration(new FeatureConfiguration());

            modelBuilder.ApplyConfiguration(new ProductFeatureConfiguration());

        }
    }
}
