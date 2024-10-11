using Backend.DTO;
using Backend.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace Backend.Services.Implementations
{
    public class ShipperService : IShipperService
    {
        IUnidadDeTrabajo Unidad;
        public ShipperService(IUnidadDeTrabajo unidadDeTrabajo) 
        { 
        this.Unidad = unidadDeTrabajo;
        }

        #region Convertir
        Shipper Convertir(ShipperDTO shipper)
        {
            return new Shipper
            {
                ShipperId = shipper.ShipperId,
                CompanyName = shipper.CompanyName
            };
        }

        ShipperDTO Convertir(Shipper shipper)
        {
            return new ShipperDTO
            {
                ShipperId = shipper.ShipperId,
                CompanyName = shipper.CompanyName
            };
        }
        #endregion

        #region CRUD
        public bool Agregar(ShipperDTO shipper)
        {
            try
            {
                Shipper entity = Convertir(shipper);
                Unidad.ShipperDAL.Add(entity);
                return Unidad.Complete();
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Editar(ShipperDTO shipper)
        {
            try
            {
                Shipper entity = Convertir(shipper);
                Unidad.ShipperDAL.Update(entity);
                return Unidad.Complete();
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Eliminar(ShipperDTO shipper)
        {
            try
            {
                Shipper entity = Convertir(shipper);
                Unidad.ShipperDAL.Remove(entity);
                return Unidad.Complete();
            }
            catch (Exception)
            {

                return false;
            }
        }

        #endregion

        #region MetodosObtener

        public ShipperDTO Obtener(int id)
        {
            try
            {
                return Convertir(Unidad.ShipperDAL.Get(id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ShipperDTO> Obtener()
        {
            try
            {
                List<ShipperDTO> list = new List<ShipperDTO>();
                var shippers = Unidad.ShipperDAL.GetAll().ToList();

                foreach ( var item in shippers)
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

        #endregion
    }
}
