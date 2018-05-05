using Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Persistence
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(int id, bool includedRelation = true);

        void Add(Product product);

        void Remove(Product product);

        Task<ICollection<Product>> GetAllProducts();
    }
}
