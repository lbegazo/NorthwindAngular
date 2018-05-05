using Northwind.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models
{

    public class NorthwindDataAccessLayer
    {
        private readonly NorthwindContext db;

        //NorthwindContext db = new NorthwindContext();

        public NorthwindDataAccessLayer(NorthwindContext db)
        {
            this.db = db;
        }

        public IEnumerable<Supplier> getAllSuppliers()
        {
            try
            {
                return db.Suppliers.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Supplier getSupplier(int id)
        {
            try
            {
                return db.Suppliers.Find(id);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public int UpdateSupplier(Supplier supplier)
        {
            try
            {
                db.Entry(supplier).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int AddSupplier(Supplier supplier)
        {
            try
            {
                db.Suppliers.Add(supplier);
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int DeleteSupplier(int id)
        {
            try
            {
                Supplier supplier = db.Suppliers.Find(id);
                db.Suppliers.Remove(supplier);
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
