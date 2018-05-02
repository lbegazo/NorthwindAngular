using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;

namespace Northwind.Controllers
{
    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {
        private readonly NorthwindContext dbContext;

        public CategoriesController(NorthwindContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("api/Categories/Index")]
        public IEnumerable<Categorie> getAllCategories()
        {
            //return dbContext.Categories.ToList();
            return null;
        }

    }
}