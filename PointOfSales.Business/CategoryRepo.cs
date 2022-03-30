using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using PointOfSales.Business;
using PointOfSales.DAL;

namespace PointOfSales.Bussiness
{
    public class CategoryRepo : ICategoryRepos
    {
        public void Add(Category category)
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                Category category = context.Categories.Find(id);
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }

        public List<Category> GetAllCategories()
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                List<Category> category = context.Categories.Include(p => p.Id).ToList();
                return category;

            }
        }

        public Category GetCategoryById(int id)
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                Category category = context.Categories.Where(p => p.Id == id).FirstOrDefault();
                return category;

            }
        }

        public void Update(Category category)
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                Category oldCategory = context.Categories.Find(category.Id);
                context.Entry(oldCategory).CurrentValues.SetValues(category);
                context.SaveChanges();

            }
        }
    }
}
