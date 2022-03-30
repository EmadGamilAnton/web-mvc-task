using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PointOfSales.Business;
using PointOfSales.DAL;

namespace PointOfSales.Bussiness
{
    public class ProductRepo : IProductRepos
    {
        public void Add(Product product)
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                Product product = context.Products.Find(id);
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }

        public List<Product> GetAllProducts()
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                List<Product> product = context.Products.ToList();
                return product;
            }
        }

        public Product GetProductById(int id)
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                Product product = context.Products.Where(p => p.Id == id).Include(p => p.Id).FirstOrDefault();
                return product;

            }
        }
        public void Update(Product product)
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                Product oldproduct = context.Products.Find(product.Id);
                context.Entry(oldproduct).CurrentValues.SetValues(product);
                context.SaveChanges();

            }
        }


    }
}
