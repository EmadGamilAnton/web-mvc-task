using PointOfSales.DAL;
using System.Collections.Generic;

namespace PointOfSales.Business
{
    public interface ISupplierRepos
    {
        void Add(Supplier supplier);
        void Update(Supplier supplier);
        void Delete(int id);
        List<Supplier> GetAllSupplier();
        Supplier GetSupplierById(int id);
    }
}
