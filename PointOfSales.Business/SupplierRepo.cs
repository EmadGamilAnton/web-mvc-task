using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PointOfSales.Business;
using PointOfSales.DAL;

namespace PointOfSales.Bussiness
{
    public class SupplierRepo : ISupplierRepos
    {
        public void Add(Supplier supplier)
        {
            using(TaskOneEntities context = new TaskOneEntities())
            {
                context.Suppliers.Add(supplier);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                Supplier supplier = context.Suppliers.Find(id);
                context.Suppliers.Remove(supplier);
                context.SaveChanges();
            }
        }

        public List<Supplier> GetAllSupplier()
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                List<Supplier> supplier = context.Suppliers.ToList();
                return supplier;

            }
        }

        public Supplier GetSupplierById(int id)
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                Supplier supplier = context.Suppliers.Where(p => p.Id == id).FirstOrDefault();
                return supplier;

            }
        }

        public void Update(Supplier supplier)
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                Supplier oldSupplier = context.Suppliers.Find(supplier.Id);
                context.Entry(oldSupplier).CurrentValues.SetValues(supplier);
                context.SaveChanges();

            }
        }
    }
}
