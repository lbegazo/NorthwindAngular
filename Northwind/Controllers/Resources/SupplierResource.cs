using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Controllers.Resources
{
    
    public class SupplierResource
    {
        public int SupplierId { get; set; }
        public string CompanyName { get; set; }     
        public ContactResource Contact { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string HomePage { get; set; }       

        public SupplierResource()
        {            
        }
    }
}
