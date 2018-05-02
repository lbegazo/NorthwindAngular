using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Controllers.Resources
{
    public class CategoryResource
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public ICollection<ProductResource> Products { get; set; }

        public CategoryResource()
        {
            Products = new HashSet<ProductResource>();
        }
    }
}
