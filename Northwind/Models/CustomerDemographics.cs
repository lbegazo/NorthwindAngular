using System;
using System.Collections.Generic;

namespace Northwind.Models
{
    public partial class CustomerDemographics
    {
        public string CustomerTypeId { get; set; }
        public string CustomerDesc { get; set; }

        

        public ICollection<Territories> CustomerCustomerDemos { get; set; }

        public CustomerDemographics()
        {
            CustomerCustomerDemos = new HashSet<Territories>();
        }
    }
}
