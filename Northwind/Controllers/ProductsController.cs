using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Northwind.Controllers.Resources;
using Northwind.Models;

namespace Northwind.Controllers
{
    [Produces("application/json")]
    public class ProductsController : Controller
    {
        private readonly NorthwindContext db;
        private readonly IMapper mapper;

        public ProductsController(NorthwindContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet("api/Products/Index")]
        public ICollection<Product> GetAllProducts()
        {
            return db.Products.ToList();
        }

        [HttpGet("api/Products/Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var product = await db.Products
                                .Include(p => p.Features)
                                .SingleOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
                return NotFound();

            var result = mapper.Map<Product, ProductResource>(product);

            return Ok(result);
        }

        [HttpPost("api/Product/Create")]
        public async Task<IActionResult> Create([FromBody] ProductResource productResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var supplier = db.Suppliers.FindAsync(productResource.SupplierId);
            if (supplier == null)
            {
                ModelState.AddModelError("SupplierId", "Invalid supplierId");
                return BadRequest(ModelState);
            }
            //if (true)
            //{
            //    ModelState.AddModelError("...", "error");
            //    return BadRequest(ModelState);
            //}

            var product = mapper.Map<ProductResource, Product>(productResource);
            db.Products.Add(product);
            await db.SaveChangesAsync();

            var result = mapper.Map<Product, ProductResource>(product);
            return Ok(result);
        }

        [HttpPut("api/Product/Edit/{id}")]
        public async Task<IActionResult> Create(int id, [FromBody] ProductResource productResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await db.Products
                                .Include(p => p.Features)
                                .SingleOrDefaultAsync(p => p.ProductId == id);
            if (product == null)            
                return NotFound();

            mapper.Map<ProductResource, Product>(productResource, product);            
            await db.SaveChangesAsync();            

            var result = mapper.Map<Product, ProductResource>(product);
            return Ok(result);
        }

        [HttpDelete("api/Product/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await db.Products
                            .Include(p => p.Features)
                            .SingleOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
                return NotFound();

            db.Products.Remove(product);
            await db.SaveChangesAsync();

            return Ok(id);
        }
    }
}