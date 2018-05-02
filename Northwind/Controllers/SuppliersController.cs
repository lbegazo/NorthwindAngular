using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly NorthwindContext db;

        public SuppliersController(NorthwindContext db)
        {
            this.db = db;
        }

        // GET: api/<controller>
        [HttpGet]
        [Route("api/Supplier/Index")]
        public IEnumerable<Supplier> Index()
        {
            return db.Suppliers.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Route("api/supplier/detail/{id}")]
        public Supplier Details(int id)
        {
            return db.Suppliers.Find(id);
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
