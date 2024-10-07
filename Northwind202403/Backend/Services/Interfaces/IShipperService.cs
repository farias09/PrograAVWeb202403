using Entities.Entities;

namespace Backend.Services.Interfaces
{
    public interface IShipperService
    {
        bool Agregar(Shipper shipper);
        bool Editar(Shipper shipper);
        bool Eliminar(Shipper shipper);

        /// <summary>
        /// Obtiene Category por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Shipper Obtener(int id);

        /// <summary>
        /// Obtiene todas las categories
        /// </summary>
        /// <returns></returns>
        List<Shipper> Obtener();
    }
}
