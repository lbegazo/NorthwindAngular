using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Models
{
    public partial class Products
    {
        public Products()
        {
            //OrderDetails = new HashSet<OrderDetails>();
        }

        [Column(Order = 1)]
        public int ProductId { get; set; }
        [Column(Order = 2)]
        public string ProductName { get; set; }
        [Column(Order = 3)]
        public int? SupplierId { get; set; }

        public Suppliers Supplier { get; set; }
        [Column(Order = 4)]
        public int? CategoryId { get; set; }
        public Categories Category { get; set; }
        [Column(Order = 5)]
        public string QuantityPerUnit { get; set; }
        [Column(Order = 6)]
        public decimal? UnitPrice { get; set; }
        [Column(Order = 7)]
        public short? UnitsInStock { get; set; }
        [Column(Order = 8)]
        public short? UnitsOnOrder { get; set; }
        [Column(Order = 9)]
        public short? ReorderLevel { get; set; }
        [Column(Order = 10)]
        public bool Discontinued { get; set; }
        //public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
