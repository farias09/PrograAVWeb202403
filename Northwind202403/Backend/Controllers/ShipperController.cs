using Backend.DTO;
using Backend.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {

        IShipperService shipperService;

        #region Constructor
        public ShipperController(IShipperService shipper)
        {
            this.shipperService = shipper;
        }

        #endregion

        #region CRUD
        // GET: api/<ShipperController>
        [HttpGet]
        public IEnumerable<ShipperDTO> Get()
        {
            return shipperService.Obtener();
        }

        // GET api/<ShipperController>/5
        [HttpGet("{id}")]
        public ShipperDTO Get(int id)
        {
            return shipperService.Obtener(id);
        }

        // POST api/<ShipperController>
        [HttpPost]
        public IActionResult Post([FromBody] ShipperDTO shipper)
        {
            shipperService.Agregar(shipper);
            return Ok(shipper);
        }

        // PUT api/<ShipperController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] ShipperDTO shipper)
        {
            shipperService.Editar(shipper);
            return Ok(shipper);
        }

        // DELETE api/<ShipperController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ShipperDTO shipper = new ShipperDTO
            {
                ShipperId = id
            };
            shipperService.Eliminar(shipper);
        }
        #endregion
    }
}
