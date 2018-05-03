using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Models
{
    public partial class Product
    {       
        
        public int ProductId { get; set; }
        
        public string ProductName { get; set; }
        
        public int? SupplierId { get; set; }

        public Supplier Supplier { get; set; }
        
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        
        public string QuantityPerUnit { get; set; }
        
        public decimal? UnitPrice { get; set; }
        
        public short? UnitsInStock { get; set; }
        
        public short? UnitsOnOrder { get; set; }
        
        public short? ReorderLevel { get; set; }
        
        public bool Discontinued { get; set; }
        //public ICollection<OrderDetails> OrderDetails { get; set; }

        public ICollection<ProductFeature> Features { get; set; }

        public Product()
        {
            //OrderDetails = new HashSet<OrderDetails>();
            Features = new HashSet<ProductFeature>();
        }
    }
}
