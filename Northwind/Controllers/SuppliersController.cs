using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Northwind.Controllers.Resources;
using Northwind.Models;
using Northwind.Persistence;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly NorthwindContext db;
        private readonly IMapper mapper;

        public SuppliersController(NorthwindContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        // GET: api/<controller>
        [HttpGet]
        [Route("api/Supplier/Index")]
        public IEnumerable<SupplierResource> Index()
        {
            var suppliers = db.Suppliers.ToList();
            return mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierResource>>(suppliers);
        }

        // GET api/<controller>/5
        [HttpGet("api/supplier/detail/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var supplier = await db.Suppliers.FindAsync(id);

            if (supplier == null)
                return NotFound();

            var result = mapper.Map<Supplier, SupplierResource>(supplier);
            return Ok(result);
        }

        // POST api/<controller>
        [HttpPost("api/Supplier/Create/")]
        public async Task<IActionResult> Create([FromBody]SupplierResource supplierResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var supplier = mapper.Map<SupplierResource, Supplier>(supplierResource);
            db.Suppliers.Add(supplier);
            await db.SaveChangesAsync();

            var result = mapper.Map<Supplier, SupplierResource>(supplier);
            return Ok(result);
        }

        // PUT api/<controller>/5
        [HttpPut("api/Supplier/Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody]SupplierResource supplierResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var supplier = await db.Suppliers.FindAsync(id);
            mapper.Map<SupplierResource, Supplier>(supplierResource, supplier);

            await db.SaveChangesAsync();

            var result = mapper.Map<Supplier, SupplierResource>(supplier);

            return Ok(result);
        }

        // DELETE api/<controller>/5
        [HttpDelete("api/Supplier/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Supplier supplier = await db.Suppliers.FindAsync(id);

            if (supplier == null)
                return NotFound();

            db.Suppliers.Remove(supplier);
            await db.SaveChangesAsync();
            return Ok(id);
        }
    }
}
