using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Controllers.Resources
{
    public class ProductResource: KeyValuePairResource
    {
        public int? SupplierId { get; set; }        

        public KeyValuePairResource Category { get; set; }        

        public string QuantityPerUnit { get; set; }

        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }
        public ICollection<int> Features { get; set; }
        public ProductResource()
        {
            Features = new HashSet<int>();
            //OrderDetails = new HashSet<OrderDetails>();
        }
    }
}
