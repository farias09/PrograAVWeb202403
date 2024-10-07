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

        public bool Agregar(Shipper shipper)
        {
            try
            {
                Unidad.ShipperDAL.Add(shipper);
                return Unidad.complete();
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Editar(Shipper shipper)
        {
            try
            {
                Unidad.ShipperDAL.Update(shipper);
                return Unidad.complete();
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Eliminar(Shipper shipper)
        {
            try
            {
                Unidad.ShipperDAL.Remove(shipper);
                return Unidad.complete();
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Shipper Obtener(int id)
        {
            try
            {
                return Unidad.ShipperDAL.Get(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Shipper> Obtener()
        {
            try
            {
                return Unidad.ShipperDAL.GetAll().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
