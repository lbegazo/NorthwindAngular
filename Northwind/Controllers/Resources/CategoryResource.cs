using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Controllers.Resources
{
    public class CategoryResource : KeyValuePairResource
    {
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public ICollection<int> Products { get; set; }
        public CategoryResource()
        {
            Products = new HashSet<int>();
        }
    }
}
