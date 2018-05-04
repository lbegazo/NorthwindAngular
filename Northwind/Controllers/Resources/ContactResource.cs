using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Controllers.Resources
{
    public class ContactResource
    {
        [Required]
        [StringLength(60)]
        public string Name { get; set; }
        [StringLength(60)]
        public string Title { get; set; }
        [StringLength(60)]
        public string Email { get; set; }
    }
}
