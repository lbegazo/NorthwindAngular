using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Controllers.Resources;
using Northwind.Models;
using Northwind.Persistence;

namespace Northwind.Controllers
{
    [Produces("application/json")]
    public class FeaturesController : Controller
    {
        private readonly NorthwindContext db;
        private readonly IMapper mapper;

        public FeaturesController(NorthwindContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet("api/Features/Index")]
        public IActionResult getAllFeatures()
        {
            var features = db.Features.ToList();
            var result = mapper.Map<ICollection<Feature>, ICollection<KeyValuePairResource>>(features);
            return Ok(result);
        }
    }
}