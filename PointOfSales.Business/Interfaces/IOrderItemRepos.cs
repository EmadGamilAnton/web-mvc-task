using PointOfSales.DAL;
using System.Collections.Generic;

namespace PointOfSales.Business
{
    public interface IOrderItemRepos
    {
        void Add(OrderItem orderItem);
        void Update(OrderItem orderItem);
        void Delete(int id);
        List<OrderItem> GetAllOrderItem();
        OrderItem GetOrderItemById(int id);
    }
}
