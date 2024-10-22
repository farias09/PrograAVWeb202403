using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ISupplierHelper
    {
        List<SupplierViewModel> GetSuppliers();
        SupplierViewModel GetSupplier(int id);
        SupplierViewModel Add(SupplierViewModel supplier);
        SupplierViewModel Update(SupplierViewModel supplier);
        void Delete(int id);    

    }
}
