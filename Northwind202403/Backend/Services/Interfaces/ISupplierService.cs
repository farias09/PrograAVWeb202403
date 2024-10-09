using Backend.DTO;
using Entities.Entities;

namespace Backend.Services.Interfaces
{
    public interface ISupplierService
    {
        SupplierDTO Get(int id);
        List<SupplierDTO> Get();
        SupplierDTO Add(SupplierDTO supplier);
        SupplierDTO Update(SupplierDTO supplier);
        void Delete(int id);

    }
}
