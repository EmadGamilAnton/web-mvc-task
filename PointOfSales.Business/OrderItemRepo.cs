using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PointOfSales.Business;
using PointOfSales.DAL;

namespace PointOfSales.Bussiness
{
    public class OrderItemRepo : IOrderItemRepos
    {
        public void Add(OrderItem orderItem)
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                context.OrderItems.Add(orderItem);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                OrderItem orderItem = context.OrderItems.Find(id);
                context.OrderItems.Remove(orderItem);
                context.SaveChanges();
            }
        }

        public List<OrderItem> GetAllOrderItem()
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                List<OrderItem> orderItem = context.OrderItems.Include(p => p.Id).ToList();
                return orderItem;

            }
        }

        public OrderItem GetOrderItemById(int id)
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                OrderItem orderItem = context.OrderItems.Where(p => p.Id == id).FirstOrDefault();
                return orderItem;

            }
        }

        public void Update(OrderItem orderItem)
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                OrderItem oldOrderItem = context.OrderItems.Find(orderItem.Id);
                context.Entry(oldOrderItem).CurrentValues.SetValues(orderItem);
                context.SaveChanges();

            }
        }
    }
}
