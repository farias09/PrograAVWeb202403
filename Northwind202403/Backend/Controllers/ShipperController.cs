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

        public ShipperController(IShipperService shipper)
        {
            this.shipperService = shipper;
        }

        // GET: api/<ShipperController>
        [HttpGet]
        public IEnumerable<Shipper> Get()
        {
            return shipperService.Obtener();
        }

        // GET api/<ShipperController>/5
        [HttpGet("{id}")]
        public Shipper Get(int id)
        {
            return shipperService.Obtener(id);
        }

            // POST api/<ShipperController>
            [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ShipperController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ShipperController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
