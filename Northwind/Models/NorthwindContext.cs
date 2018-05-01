using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
            #region Suppliers

            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.HasKey(e => e.SupplierId);

                entity.HasIndex(e => e.CompanyName)
                    .HasName("CompanyName");

                entity.HasIndex(e => e.PostalCode)
                    .HasName("PostalCode");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.Address).HasMaxLength(60);

                entity.Property(e => e.City).HasMaxLength(15);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ContactName).HasMaxLength(30);

                entity.Property(e => e.ContactTitle).HasMaxLength(30);

                entity.Property(e => e.Country).HasMaxLength(15);

                entity.Property(e => e.Fax).HasMaxLength(24);

                entity.Property(e => e.HomePage).HasColumnType("ntext");

                entity.Property(e => e.Phone).HasMaxLength(24);

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.Region).HasMaxLength(15);
            });

            #endregion Suppliers

            #region Categories

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(c => c.CategoryId);

                entity.Property(c => c.CategoryName)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(c => c.Description).HasColumnType("nText");

                entity.Property(c => c.Picture).HasColumnType("image");

            });

            #endregion Categories

            #region Shippers

            modelBuilder.Entity<Shippers>(entity =>
            {
                entity.HasKey(e => e.ShipperId);

                entity.Property(e => e.ShipperId).HasColumnName("ShipperID");

                entity.Property("CompanyName")
                    .HasMaxLength(40)
                    .IsRequired();

                entity.Property("Phone")
                    .HasMaxLength(24);

            });

            #endregion Shippers

            #region Region

            modelBuilder.Entity<Region>(entity =>
                {
                    entity.HasKey(r => r.RegionId);

                    entity.Property(r => r.RegionId)
                        .HasColumnName("RegionID")
                        .ValueGeneratedNever();

                    entity.Property(r => r.RegionDescription)
                        .IsRequired()
                        .HasColumnType("nchar(50)");

                });

            #endregion Region

            #region Territories

            modelBuilder.Entity<Territories>(entity =>
            {
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
                        
            });

            #endregion Territories

            #region Products

            modelBuilder.Entity<Products>(entity =>
            {
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
            });

            #endregion Products

            #region CustomerDemographics

            modelBuilder.Entity<CustomerDemographics>(entity => {
                 entity.HasKey(cd => cd.CustomerTypeId);

                entity.Property(cd => cd.CustomerTypeId)
                    .HasColumnType("nchar(10)")
                    .HasColumnName("CustomerTypeID");
                entity.Property(cd => cd.CustomerDesc).HasColumnType("ntext");
            });

            #endregion CustomerDemographics

            #region Customer

            modelBuilder.Entity<Customers>(entity => {

                entity.HasKey(c => c.CustomerId);

                entity.Property(c => c.CustomerId).HasColumnType("nchar(5)");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ContactName).HasMaxLength(30);

                entity.Property(e => e.ContactTitle).HasMaxLength(30);

                entity.Property(e => e.Address).HasMaxLength(60);

                entity.Property(e => e.City).HasMaxLength(15);

                entity.Property(e => e.Region).HasMaxLength(15);

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.Country).HasMaxLength(15);

                entity.Property(e => e.Phone).HasMaxLength(24);

                entity.Property(e => e.Fax).HasMaxLength(24);  
            });


            #endregion Customer

            #region CustomerCustomerDemo

            modelBuilder.Entity<CustomerCustomerDemo>(entity =>
            {
                entity.HasKey(cc => new { cc.CustomerId, cc.CustomerTypeId });

                entity.HasOne(cc => cc.Customer)
                    .WithMany(c => c.CustomerCustomerDemos)
                    .HasForeignKey(cc => cc.CustomerId);

                entity.HasOne(cc => cc.CustomerDemographic)
                    .WithMany(cd => cd.CustomerCustomerDemos)
                    .HasForeignKey(cc => cc.CustomerTypeId);
                
            });
                
            #endregion CustomerCustomerDemo
        }
    }
}
