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
using Northwind.Persistence;

namespace Northwind.Controllers
{
    [Produces("application/json")]
    public class ProductsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IProductRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public ProductsController(IMapper mapper, IProductRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("api/Products/Index")]
        public async Task<ICollection<ProductResource>> GetAllProducts()
        {
            var products = await repository.GetAllProducts();
            return Mapper.Map<ICollection<Product>, ICollection<ProductResource>>(products);
        }

        [HttpGet("api/Products/Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var product = await repository.GetProduct(id, true);
            
            if (product == null)
                return NotFound();

            var result = mapper.Map<Product, ProductResource>(product);

            return Ok(result);
        }

        [HttpPost("api/Product/Create")]
        public async Task<IActionResult> Create([FromBody] ProductResource productResource)
        //public IActionResult Create([FromBody] ProductResource productResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            #region Por Eliminar

            //var supplier = db.Suppliers.FindAsync(productResource.SupplierId);
            //if (supplier == null)
            //{
            //    ModelState.AddModelError("SupplierId", "Invalid supplierId");
            //    return BadRequest(ModelState);
            //}
            //if (true)
            //{
            //    ModelState.AddModelError("...", "error");
            //    return BadRequest(ModelState);
            //}

            #endregion Por Eliminar

            var product = mapper.Map<ProductResource, Product>(productResource);
            
            repository.Add(product);
            await unitOfWork.CompleteAsync();

            product = await repository.GetProduct(product.Id);

            var result = mapper.Map<Product, ProductResource>(product);
            
            return Ok(result);
        }

        [HttpPut("api/Product/Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] ProductResource productResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await repository.GetProduct(id);
          
            if (product == null)
                return NotFound();

            mapper.Map<ProductResource, Product>(productResource, product);
            await unitOfWork.CompleteAsync();

            product = await repository.GetProduct(product.Id);
            var result = mapper.Map<Product, ProductResource>(product);
            return Ok(result);
        }

        [HttpDelete("api/Product/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await repository.GetProduct(id, includedRelation: false);

            if (product == null)
                return NotFound();

            repository.Remove(product);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }
    }
}