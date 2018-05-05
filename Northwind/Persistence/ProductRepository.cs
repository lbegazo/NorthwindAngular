using Microsoft.EntityFrameworkCore;
using Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly NorthwindContext db;

        public ProductRepository(NorthwindContext db)
        {
            this.db = db;
        }

        public void Add(Product product)
        {
            db.Products.Add(product);
        }

        public async Task<Product> GetProduct(int id, bool includedRelation = true)
        {
            if (!includedRelation)
                return await db.Products.FindAsync(id);

            return await db.Products
                              .Include(p => p.Features)
                              .Include(p => p.Category)
                              .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<Product>> GetAllProducts()
        {
            return await db.Products.Include(p => p.Category).ToListAsync();            
        }

        public void Remove(Product product)
        {
            db.Products.Remove(product);
        }

    }
}
