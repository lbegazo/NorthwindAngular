using System;
using System.Collections.Generic;

namespace Northwind.Models
{
    public partial class EmployeeTerritorie
    {
        public int EmployeeId { get; set; }
        public string TerritoryId { get; set; }

        public Employee Employee { get; set; }
    }
}
