using Northwind.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NorthwindContext db;

        public UnitOfWork(NorthwindContext db)
        {
            this.db = db;
        }


        public async Task CompleteAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
