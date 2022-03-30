using PointOfSales.DAL;
using System.Collections.Generic;

namespace PointOfSales.Business
{
    public interface ICustomerRepos
    {
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
    }
}
