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
    public class CategoriesController : Controller
    {
        private readonly NorthwindContext dbContext;
        private readonly IMapper mapper;

        public CategoriesController(NorthwindContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet("api/Categories/Index")]
        public IEnumerable<CategoryResource> getAllCategories()
        {
            var categories = dbContext.Categories.ToList();
            return mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
        }

        [HttpGet("api/Categories/Details/{id}")]
        public IActionResult Detail(int id)
        {
            var category = dbContext.Categories.Find(id);

            if (category == null)
                return NotFound();

            var result=mapper.Map<Category, CategoryResource>(category);
            return Ok(result);
        }

    }
}