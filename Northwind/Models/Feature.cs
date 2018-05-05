using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models
{
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<ProductFeature> Products { get; set; }

        public Feature()
        {
            Products = new HashSet<ProductFeature>();
        }
    }
}
