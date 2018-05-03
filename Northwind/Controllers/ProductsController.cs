using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Controllers.Resources;
using Northwind.Models;

namespace Northwind.Controllers
{
    [Produces("application/json")]
    //[Route("api/Products")]
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
        public ProductResource Details(int id)
        {
            var product = db.Products.Find(id);
            return mapper.Map<Product, ProductResource>(product);
        }

        [HttpPost("api/Product/Create")]
        public async Task<IActionResult> Create([FromBody] ProductResource productResource)
        {
            var product = mapper.Map<ProductResource, Product>(productResource);
            db.Products.Add(product);
            await db.SaveChangesAsync();

            var result = mapper.Map<Product, ProductResource>(product);
            return Ok(result);
        }
    }
}