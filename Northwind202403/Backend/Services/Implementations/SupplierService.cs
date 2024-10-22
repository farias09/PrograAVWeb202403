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

        public SupplierDTO Update(SupplierDTO supplier)
        {
            try
            {
                _Unidad.SupplierDAL.Update(Convertir(supplier));
                return supplier;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public SupplierDTO Delete(SupplierDTO supplier)
        {
            try
            {
                _Unidad.SupplierDAL.Remove(Convertir(supplier));
                return supplier;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public SupplierDTO Get(int id)
        {
            try
            {
                return Convertir(_Unidad.SupplierDAL.Get(id));

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<SupplierDTO> Get()
        {
            try
            {
                List<SupplierDTO> list = new List<SupplierDTO>();
                var suppliers = _Unidad.SupplierDAL.GetAll().ToList();

                foreach (var item in suppliers)
                {
                    list.Add(Convertir(item));
                }

                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
