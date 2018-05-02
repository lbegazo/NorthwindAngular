using System;
using System.Collections.Generic;

namespace Northwind.Models
{
    public partial class Region
    {
        public Region()
        {
            Territories = new HashSet<Territorie>();
        }

        public int RegionId { get; set; }
        public string RegionDescription { get; set; }

        public ICollection<Territorie> Territories { get; set; }
    }
}
