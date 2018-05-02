using System;
using System.Collections.Generic;

namespace Northwind.Models
{
    public partial class Territorie
    {
        public string TerritoryId { get; set; }
        public string TerritoryDescription { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
    }
}
