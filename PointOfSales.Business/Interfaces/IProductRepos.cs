using PointOfSales.DAL;
using System.Collections.Generic;

namespace PointOfSales.Business
{
    public interface IProductRepos
    {
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
        List<Product> GetAllProducts();
        Product GetProductById(int id);
    }
}
