using Backend.DTO;
using Entities.Entities;

namespace Backend.Services.Interfaces
{
    public interface IShipperService
    {
        bool Agregar(ShipperDTO shipper);
        bool Editar(ShipperDTO shipper);
        bool Eliminar(ShipperDTO shipper);

        /// <summary>
        /// Obtiene Category por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ShipperDTO Obtener(int id);

        /// <summary>
        /// Obtiene todas las categories
        /// </summary>
        /// <returns></returns>
        List<ShipperDTO> Obtener();
    }
}
