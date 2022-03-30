using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PointOfSales.Business;
using PointOfSales.DAL;

namespace PointOfSales.Bussiness
{
    public class OrderRepo : IOrderRepos
    {
        public void Add(Order order)
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                Order order = context.Orders.Find(id);
                context.Orders.Remove(order);
                context.SaveChanges();
            }
        }

        public List<Order> GetAllOrders()
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                List<Order> order = context.Orders.Include(p => p.Id).ToList();
                return order;

            }
        }

        public Order GetOrderById(int id)
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                Order order = context.Orders.Where(p => p.Id == id).FirstOrDefault();
                return order;

            }
        }

        public void Update(Order order)
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                Order oldOrder = context.Orders.Find(order.Id);
                context.Entry(oldOrder).CurrentValues.SetValues(order);
                context.SaveChanges();

            }
        }
    }
}
