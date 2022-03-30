using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PointOfSales.Business;
using PointOfSales.DAL;

namespace PointOfSales.Bussiness
{
    public class CustomerRepo : ICustomerRepos
    {
        public void Add(Customer customer)
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                Customer customer = context.Customers.Find(id);
                context.Customers.Remove(customer);
                context.SaveChanges();
            }
        }

        public List<Customer> GetAllCustomers()
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                List<Customer> customer = context.Customers.Include(p => p.Id).ToList();
                return customer;

            }
        }

        public Customer GetCustomerById(int id)
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                Customer customer = context.Customers.Where(p => p.Id == id).FirstOrDefault();
                return customer;

            }
        }

        public void Update(Customer customer)
        {
            using (TaskOneEntities context = new TaskOneEntities())
            {
                Customer oldCustomer = context.Customers.Find(customer.Id);
                context.Entry(oldCustomer).CurrentValues.SetValues(customer);
                context.SaveChanges();

            }
        }
    }
}
