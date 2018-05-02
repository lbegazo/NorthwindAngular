using System;
using System.Collections.Generic;

namespace Northwind.Models
{
    public partial class Categorie
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public ICollection<Product> Products { get; set; }

        public Categorie()
        {
            Products = new HashSet<Product>();
        }
    }
}
