using PointOfSales.DAL;
using System.Collections.Generic;

namespace PointOfSales.Business
{
    public interface IOrderRepos
    {
        void Add(Order order);
        void Update(Order order);
        void Delete(int id);
        List<Order> GetAllOrders();
        Order GetOrderById(int id);

    }
}
