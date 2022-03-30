using PointOfSales.DAL;
using System.Collections.Generic;

namespace PointOfSales.Business
{
    public interface ICategoryRepos
    {
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
    }
}
