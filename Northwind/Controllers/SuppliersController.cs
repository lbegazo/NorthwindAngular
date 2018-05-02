using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Northwind.Controllers.Resources;
using Northwind.Models;

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
        public SupplierResource Details(int id)
        {
            var supplier = db.Suppliers.Find(id);
            return mapper.Map<Supplier, SupplierResource>(supplier);
        }

        // POST api/<controller>
        [HttpPost("api/Supplier/Create/")]
        public IActionResult Create([FromBody]Supplier supplier)
        {
            //return db.AddSupplier(supplier);
            return Ok(supplier);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Route("api/Supplier/Edit/")]
        public void Edit([FromBody]Supplier supplier)
        {
            db.Entry(supplier).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Route("api/Supplier/delete/{id}")]
        public int Delete(int id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            db.Suppliers.Remove(supplier);
            return 1;
        }
    }
}
