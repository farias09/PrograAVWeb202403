using Backend.DTO;
using Backend.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace Backend.Services.Implementations
{
    public class SupplierService : ISupplierService
    {

        IUnidadDeTrabajo _Unidad;

        public SupplierService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _Unidad = unidadDeTrabajo;
        }

        #region Convertir
        Supplier Convertir(SupplierDTO supplier)
        {
            return new Supplier
            {
                SupplierId = supplier.SupplierId,
                CompanyName = supplier.CompanyName
            };
        }

        SupplierDTO Convertir(Supplier supplier)
        {
            return new SupplierDTO
            {
                SupplierId = supplier.SupplierId,
                CompanyName = supplier.CompanyName
            };
        }
        #endregion

        public SupplierDTO Add(SupplierDTO supplier)
        {
            try
            {
                _Unidad.SupplierDAL.Add(Convertir(supplier));
                return supplier;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public SupplierDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<SupplierDTO> Get()
        {
            throw new NotImplementedException();
        }

        public SupplierDTO Update(SupplierDTO supplier)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
